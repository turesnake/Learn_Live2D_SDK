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
    进场挂在 live2d 资源的主节点上, 好像只在 editor 中起效 ?






























