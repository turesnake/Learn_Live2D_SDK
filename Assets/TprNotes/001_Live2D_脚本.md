# ======================================================== #
#          001  Live2D  脚本
# ======================================================== #






# -----------------------
#  CubismRenderer

    和 meshrenderer 经常一起出现, 绑定给一个面片



# -----------------------
# CubismDrawable

    和 CubismRenderer, meshrenderer 经常一起出现, 绑定给一个面片
    ---

    drawable: 可拖拉的



# -----------------------
#  CubismRaycaster
    专用 射线投射  raycast
    ---

    它是通过遍历所有 live2d 面片来实现的, 很暴力;







# -----------------------
# CubismRaycastHit
    CubismRaycaster 的 Raycast() 的返回值



# -----------------------
# CubismRaycastablePrecision

    专用 Raycast 的精度: 基于 AABB盒, 还是基于 三角面


# -----------------------
# CubismRaycastable
    内置一个 CubismRaycastablePrecision 变量的脚本, 绑定到 go 上来配置参数

    和 CubismRenderer, meshrenderer 经常一起出现, 绑定给一个面片




# -----------------------
# CubismSortingMode

    面片排序规则:   
        BackToFrontZ
        FrontToBackZ
        BackToFrontOrder
        FrontToBackOrder



# -----------------------
# CubismModel
    进场挂在 live2d 资源的主节点上, 
    好像只在 editor 中起效 ? 好像不是的
    ---

# --- CubismModel.Parameters   
    那些程序可以控制的参数;


# -----------------------
# CubismParameter
    那些程序可以控制的参数;
    ---
    本脚本挂载在 prefab.Parameters 节点下的所有 子节点上;
    ---
    可通过 CubismModel.Parameters  集中拿到



# -----------------------
#  CubismDisplayInfoParameterName
    通常 和 CubismParameter 一起, 绑定在一个 prefab.Parameters 节点下的 子节点 上;
    ---
    Get the parameter name from cdi3.json and save the display name.



# -----------------------
#  CubismModel3Json

    动态加载 类, 调用 CubismModel3Json.LoadAtPath() 直接读取一个 Koharu.model3.json 文件, 
    再配合 ToModel(),
    就能将这个角色加到到 runtime 场景中,
    ---
    而且, 这个 CubismModel3Json 实例自己好像就是 JsonUtility.FromJson() 的返回值;





# ================================== #
#    全部 namespace
# ================================== #

namespace Live2D.Cubism.Core
namespace Live2D.Cubism.Core.Unmanaged

namespace Live2D.Cubism.Editor
namespace Live2D.Cubism.Editor.Importers
namespace Live2D.Cubism.Editor.OriginalWorkflow
namespace Live2D.Cubism.Editor.Deleters
namespace Live2D.Cubism.Editor.Inspectors

namespace Live2D.Cubism.Framework
namespace Live2D.Cubism.Framework.Expression
namespace Live2D.Cubism.Framework.HarmonicMotion
namespace Live2D.Cubism.Framework.Json
namespace Live2D.Cubism.Framework.LookAt
namespace Live2D.Cubism.Framework.Motion
namespace Live2D.Cubism.Framework.MotionFade
namespace Live2D.Cubism.Framework.MouthMovement
namespace Live2D.Cubism.Framework.Physics
namespace Live2D.Cubism.Framework.Pose
namespace Live2D.Cubism.Framework.Raycasting
namespace Live2D.Cubism.Framework.Tasking
namespace Live2D.Cubism.Framework.UserData
namespace Live2D.Cubism.Plugins.Editor

namespace Live2D.Cubism.Rendering
namespace Live2D.Cubism.Rendering.Masking




# ================================== #
#    自动运行的 Update()/LateUpdate()
# ================================== #

# 如果场景中有 live2d 文件, 如下 Update()/LateUpdate() 会在 editor 模式下不停运行
Live2D.Cubism.Core.CubismModel
Live2D.Cubism.Rendering.Masking.CubismMaskCommandBuffer
Live2D.Cubism.Framework.CubismUpdateController
Live2D.Cubism.Rendering.CubismRenderController



# 只要项目中安装了 live2d sdk, 如下 Update()/LateUpdate() 会在 editor 模式下不停运行
 Live2D.Cubism.Rendering.Masking.CubismMaskCommandBuffer
    ---
    这也是全局唯一一处 注释中有 singleton 的脚本



# 当运行 官方案例 Animaion 时, 运行时在执行的 Update()/LateUpdate()
Live2D.Cubism.Core.CubismModel
Live2D.Cubism.Rendering.Masking.CubismMaskCommandBuffer
Live2D.Cubism.Framework.MotionFade.CubismFadeController
Live2D.Cubism.Framework.Expression.CubismExpressionController
Live2D.Cubism.Framework.Pose.CubismPoseController
Live2D.Cubism.Framework.CubismUpdateController
Live2D.Cubism.Framework.CubismEyeBlinkController
Live2D.Cubism.Rendering.CubismRenderController
Live2D.Cubism.Core.CubismTaskableModel
Live2D.Cubism.Core.Unmanaged.CubismUnmanagedModel
























