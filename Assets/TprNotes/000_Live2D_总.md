# ======================================================== #
#          000  Live2D   总
# ======================================================== #



# Cubism Editor:
    编辑 2d美术图层资源, 用它们来建模, 绑骨骼, 做动画;


# Cubism SDK
    A Cubism SDK is a software development kit for utilizing models created with Cubism Editor in user applications.
    All source code other than the Cubism Core library is available on GitHub, where you can also check for the latest updates.

    At present, SDK are available for Unity, for native applications, and for web browsers. If you are interested in consumer application development, please contact us.
    --

# Cubism SDK For Unity:
    可直接装入 unity 的插件;

    
# ------------------------------------------- #
#         文件类型
# ------------------------------------------- #
https://docs.live2d.com/en/cubism-editor-manual/file-type-and-extension/

# ------------------------
# Modeling (模型相关的)

# .cmo3		
    The Model Workspace is an editor for creating Live2D models.
    The model data handled by this editor are .cmo3 format files.

# .cmp3		
    The Model Workspace exports parts of the model in .cmp3 format.
    Parts can be loaded into other model data.

# .moc3		
    The Model Workspace will ultimately export the file in .moc3 format.
    .moc3 is the Live2D model data used in the program.

# .model3.json		
    Export a model settings file. The data to be linked are as follows.
    • Live2D model data (.moc3) to be used in the program
    • Texture data (.png)
    • Physics setting data (.physics3.json)
    • List of parameters set for blinking and lip-sync

# .physics3.json		
    Export physics settings.

# .physics3.json 
    is the physics setting file used in the program.

# .userdata3.json		
    This data contains the set values of user data.


# ------------------------
# Animation (动画)

# .can3		
    The Animation Workspace is an editor for creating animations using Live2D models.
    This editor’s projects are saved as .can3 format files.

# .ctmp3		
    Animation template data.

# .motion3.json		
    The Animation Workspace will eventually export a .motion.json format file.
    .motion3.json is the motion data for the Live2D model used in the program.


# ------------------------
# Cubism3 Viewer (for OW) 

# .pose3.json		    
    This data is used to reflect the arm switching mechanism created in the model and motion.

# .exp3.json		
    Data converted from .motion3.json for facial expressions created in the Animation Workspace as .exp3.json.


# -------------------------------------
# Specifications changed from Cubism 3
.cmo3:
Model data now includes data for physics settings.

.model3.json:
Motion data is no longer included.

.motion3.json:
The [.mtn] in Cubism 2.1 has been changed to [.motion3.json]. (extension change)




# ------------------------------------------- #
#                      杂
# ------------------------------------------- #

# 若发现 MOC3 files 加载到 unity 中引发崩溃的话, 可下载工具:
    https://docs.live2d.com/en/cubism-editor-manual/moc3-consistency-checker/?_gl=1*18stnb0*_ga*MTIwMjkzNjM5NS4xNjkxNjY2NzA4*_ga_VH6T56L1P1*MTY5MTY2NjcwOC4xLjEuMTY5MTY2NzAxNi42MC4wLjA. 
    ---
    来检查文件;


# 若发现 角色图层不对:
https://docs.live2d.com/en/cubism-sdk-tutorials/sortrendering/

改 CubismRenderController Mode 为 BackToFrontOrder






































