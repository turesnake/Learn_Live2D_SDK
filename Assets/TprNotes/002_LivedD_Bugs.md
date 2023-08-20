# ==================================================== #
#        002   Live2D  Bugs
# ==================================================== #


# ------------------------------------------------- #
# NullReferenceException: Object reference not set to an instance of an object
Live2D.Cubism.Framework.MotionFade.CubismFadeStateObserver.OnStateEnter (UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, System.Int32 layerIndex, UnityEngine.Animations.AnimatorControllerPlayable controller) (at Assets/3rd-Party/Live2D/Cubism/Framework/MotionFade/CubismFadeStateObserver.cs:205)
---

因为 角色 CubismFadeController 组件的 CubismFadeMotionList 为空, 没有绑定;
--
通常, 资源里有现成的 配置文件 可以绑定, 































