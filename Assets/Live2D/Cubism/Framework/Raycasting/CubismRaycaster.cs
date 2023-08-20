/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at https://www.live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */


using Live2D.Cubism.Core;
using Live2D.Cubism.Rendering;
using System.Collections.Generic;
using UnityEngine;


namespace Live2D.Cubism.Framework.Raycasting
{
    /// <summary>
    /// Allows casting rays against <see cref="CubismRaycastable"/>s.
    /// </summary>
    public sealed class CubismRaycaster : MonoBehaviour
    {

        /* 
            Raycastables
            RaycastablePrecisions
            ---
            存储了一个角色中, 绑定了 CubismRaycastable 的 面片 的数据 (一一对应的, 可用同一个 idx 在这两个 array中遍历)
        */
        private CubismRenderer[] Raycastables { get; set; } // 绑定了 CubismRaycastable 的 CubismRenderer 组件
        private CubismRaycastablePrecision[] RaycastablePrecisions { get; set; } // 绑定了 CubismRaycastable 的 CubismRaycastablePrecision 组件

        //CubismRenderer[] Raycastables = null;
        //CubismRaycastablePrecision[] RaycastablePrecisions = null;



        /// <summary>
        ///     Refreshes the controller. Call this method after adding and/or removing <see cref="CubismRaycastable"/>.
        ///     刷新 Raycastables, RaycastablePrecisions 两个容器数据
        /// </summary>
        private void Refresh()
        {
            var candidates = this
                .FindCubismModel()
                .Drawables;


            // Find raycastable drawables.
            var raycastables = new List<CubismRenderer>();
            var raycastablePrecisions = new List<CubismRaycastablePrecision>();

            print("koko Refresh candidates.Length = " + candidates.Length );


            for (var i = 0; i < candidates.Length; i++)
            {
                // Skip non-raycastables.
                if (candidates[i].GetComponent<CubismRaycastable>() == null)
                {
                    continue;
                }


                raycastables.Add(candidates[i].GetComponent<CubismRenderer>());
                raycastablePrecisions.Add(candidates[i].GetComponent<CubismRaycastable>().Precision);
            }


            // Cache raycastables.
            Raycastables = raycastables.ToArray();
            RaycastablePrecisions = raycastablePrecisions.ToArray();

            print("koko -1- Raycastables = " + (Raycastables!=null));
            print("koko -2- Raycastables.Length = " + Raycastables.Length );
        }

        #region Unity Event Handling

        /// <summary>
        /// Called by Unity. Makes sure cache is initialized.
        /// </summary>
        private void Start()
        {
            // Initialize cache.
            Refresh();
        }

        #endregion

        /// <summary>
        /// Casts a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="result">The result of the cast.</param>
        /// <param name="maximumDistance">[Optional] The maximum distance of the ray.</param>
        /// <returns><see langword="true"/> in case of a hit; <see langword="false"/> otherwise.</returns>
        /// <returns>The numbers of drawables had hit</returns>
        public int Raycast(Vector3 origin, Vector3 direction, CubismRaycastHit[] result, float maximumDistance = Mathf.Infinity)
        {
            return Raycast(new Ray(origin, direction), result, maximumDistance);
        }

        /// <summary>
        /// Casts a ray.
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="result">The result of the cast.</param>
        /// <param name="maximumDistance">[Optional] The maximum distance of the ray.</param>
        /// <returns><see langword="true"/> in case of a hit; <see langword="false"/> otherwise.</returns>
        /// <returns>The numbers of drawables had hit</returns>
        public int Raycast(Ray ray, CubismRaycastHit[] result, float maximumDistance = Mathf.Infinity)
        {

            // 通常 面片都位于 xy平面, 相机朝向 z+ 方向

            // Cast ray against model plane.
            var intersectionInWorldSpace = ray.origin + ray.direction * (ray.direction.z / ray.origin.z);
            var intersectionInLocalSpace = transform.InverseTransformPoint(intersectionInWorldSpace);
            intersectionInLocalSpace.z = 0;

            //print("WorldSpace:" + intersectionInWorldSpace.ToString() + "; \n LocalSpace:" + intersectionInLocalSpace.ToString() );   // tpr debug;


            var distance = intersectionInWorldSpace.magnitude;


            // Return non-hits.
            if (distance > maximumDistance)
            {
                return 0;
            }

            // Cast against each raycastable.
            var hitCount = 0;

            print("koko Raycastables = " + (Raycastables!=null));
            print("koko Raycastables.Length = " + Raycastables.Length );

            for (var i = 0; i < Raycastables.Length; i++)
            {
                var raycastable = Raycastables[i];
                var raycastablePrecision = RaycastablePrecisions[i];


                // Skip inactive raycastables.
                if (!raycastable.MeshRenderer.enabled)
                {
                    continue;
                }

                var bounds = raycastable.Mesh.bounds;


                // Skip non hits (bounding box)
                if (!bounds.Contains(intersectionInLocalSpace))
                {
                    continue;
                }

                // Do detailed hit-detection against mesh if requested.
                if (raycastablePrecision == CubismRaycastablePrecision.Triangles)
                {
                    if (!ContainsInTriangles(raycastable.Mesh, intersectionInLocalSpace))
                    {
                        continue;
                    }
                }


                result[hitCount].Drawable = raycastable.GetComponent<CubismDrawable>();
                result[hitCount].Distance = distance;
                result[hitCount].LocalPosition = intersectionInLocalSpace;
                result[hitCount].WorldPosition = intersectionInWorldSpace;


                ++hitCount;


                // Exit if result buffer is full.
                if (hitCount == result.Length)
                {
                    break;
                }
            }


            return hitCount;
        }


        /// <summary>
        /// Check the point is inside polygons.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="inputPosition"></param>
        /// <returns></returns>
        private bool ContainsInTriangles(Mesh mesh, Vector3 inputPosition)
        {
            for (var i = 0; i < mesh.triangles.Length; i+=3)
            {
                var vertexPositionA = mesh.vertices[mesh.triangles[i]];
                var vertexPositionB = mesh.vertices[mesh.triangles[i + 1]];
                var vertexPositionC = mesh.vertices[mesh.triangles[i + 2]];

                var crossProduct1 =
                    (vertexPositionB.x - vertexPositionA.x) * (inputPosition.y - vertexPositionB.y) -
                    (vertexPositionB.y - vertexPositionA.y) * (inputPosition.x - vertexPositionB.x);
                var crossProduct2 =
                    (vertexPositionC.x - vertexPositionB.x) * (inputPosition.y - vertexPositionC.y) -
                    (vertexPositionC.y - vertexPositionB.y) * (inputPosition.x - vertexPositionC.x);
                var crossProduct3 =
                    (vertexPositionA.x - vertexPositionC.x) * (inputPosition.y - vertexPositionA.y) -
                    (vertexPositionA.y - vertexPositionC.y) * (inputPosition.x - vertexPositionA.x);

                if ((crossProduct1 > 0 && crossProduct2 > 0 && crossProduct3 > 0) ||
                    (crossProduct1 < 0 && crossProduct2 < 0 && crossProduct3 < 0))
                {
                    return true;
                }
            }


            return false;
        }
    }
}
