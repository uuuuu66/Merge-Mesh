# Merge-Mesh
mesh合并
2种方式
创建空物体->在空物体上添加mesh filter组件->把需要合并的物体作为空物体的子物体->选中空物体->tool-mesh-combine->生成mesh
创建空物体添加脚本chinarMergeMesh->把需要合并的物体作为空物体的子物体->运行后会生成obj文件