/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at https://www.live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */


using Live2D.Cubism.Core;
using UnityEngine;


namespace Live2D.Cubism.Framework.Raycasting
{
    /// <summary>
    /// Contains raycast information.
    /// </summary>
    public struct CubismRaycastHit
    {
        /// <summary>
        /// The hit <see cref="CubismDrawable"/>.
        /// </summary>
        public CubismDrawable Drawable;

        /// <summary>
        /// The distance the ray traveled until it hit the <see cref="CubismDrawable"/>.  玩家点击点 到 面片平面的 距离,  没啥软用
        /// </summary>
        public float Distance;

        /// <summary>
        /// The hit position local to the <see cref="CubismDrawable"/>.   -  仅仅是 玩家点击的 pos,  不是这个 面片的 pos....
        /// </summary>
        public Vector3 LocalPosition;

        /// <summary>
        /// The hit position in world coordinates.  --  仅仅是 玩家点击的 pos,  不是这个 面片的 pos....
        /// </summary>
        public Vector3 WorldPosition;
    }
}
