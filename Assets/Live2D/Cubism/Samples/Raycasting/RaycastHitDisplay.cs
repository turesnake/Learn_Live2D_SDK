/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at https://www.live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */


using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Raycasting;


namespace Live2D.Cubism.Samples.Raycasting
{
    /// <summary>
    /// Casts rays against a <see cref="Model"/> and displays results.
    /// </summary>
    public sealed class RaycastHitDisplay : MonoBehaviour
    {


        public Transform mainRoleTF; // 确定角色面片所在的 xy 平面;


        /// <summary>
        /// <see cref="CubismModel"/> to cast rays against.
        /// </summary>
        [SerializeField]
        public CubismModel Model;


        /// <summary>
        /// UI element to display results in.
        /// </summary>
        [SerializeField]
        public UnityEngine.UI.Text ResultsText;


        /// <summary>
        /// <see cref="CubismRaycaster"/> attached to <see cref="Model"/>.
        /// </summary>
        private CubismRaycaster Raycaster { get; set; }

        /// <summary>
        /// Buffer for raycast results.
        /// </summary>
        private CubismRaycastHit[] Results { get; set; }


        /// <summary>
        /// Hit test.
        /// </summary>
        private void DoRaycast()
        {
            // Cast ray from pointer position.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //print( "koko origin:" + ray.origin.ToString() + ", \n direction:" + ray.direction.ToString() );


            // tpr: 在原始代码中, live2d 并不支持 透视相机 中的点击
            // 添加如下代码来修复
            // 现在同时支持 透视/正交 相机里的点击了
            var zLen = Mathf.Abs( mainRoleTF.position.z - ray.origin.z );
            var t = zLen / Vector3.Dot( Vector3.forward, ray.direction );
            Vector3 dstPos = ray.origin + ray.direction * t; // 这个点位于 mainRoleTF 所在的 xy 平面上;
            //ShowPole( ray.origin, dstPos );
        

            // 一个模仿 正交相机效果的 ray:
            Ray newRay = new Ray( dstPos - Vector3.forward, Vector3.forward );

            //------
            //var hitCount = Raycaster.Raycast(ray, Results);
            var hitCount = Raycaster.Raycast(newRay, Results);


            // Return early if nothing was hit.
            if (hitCount == 0)
            {
                ResultsText.text = "0";
                return;
            }


            // Show results.
            ResultsText.text = hitCount + "\n";


            for (var i = 0; i < hitCount; i++)
            {
                ResultsText.text += Results[i].Drawable.name + "\n";
            }
        }

        #region Unity Event Handling

        /// <summary>
        /// Called by Unity. Initializes instance.
        /// </summary>
        private void Start()
        {
            Raycaster = Model.GetComponent<CubismRaycaster>();
            Results = new CubismRaycastHit[4]; 


            Debug.Assert( mainRoleTF );
        }

        /// <summary>
        /// Called by Unity. Triggers raycasting.
        /// </summary>
        private void Update()
        {
            // Return early in case of no user interaction.
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }


            DoRaycast();
        }



        // tpr: debug 用, 画 ray:
        void ShowPole( Vector3 srcPos_, Vector3 dstPos_ ) 
        {

            var midPos = (srcPos_+dstPos_) * 0.5f;
            var dir = dstPos_ - srcPos_;
            float radius = 0.03f;

            var newgo = GameObject.CreatePrimitive( PrimitiveType.Cube );
            newgo.name = "koko_1";
            var tf = newgo.transform;

            tf.position = midPos;
            tf.LookAt( dstPos_, Vector3.up );
            tf.localScale = new Vector3( radius, radius, dir.magnitude );
        }



        #endregion
    }
}
