using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshTool
{
    [MenuItem("Tool/Mesh/Combine")]
    public static void MeshCombine()
    {
        GameObject obj = (GameObject)Selection.activeObject; //场景中选择的物体
        MeshFilter[] filters = obj.GetComponentsInChildren<MeshFilter>(); // 获取子物体的MeshFilter

        CombineInstance[] combiners = new CombineInstance[filters.Length]; // 根据子物体的MeshFilter数量来创建CombineInstance数组

        for (int i = 0; i < filters.Length; i++)
        {
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix; // 这里其实不是transform 组件上的transform，其实算是一种作表转换
        }

        Mesh finalMesh = new Mesh(); // 创建一个新的mesh
        finalMesh.CombineMeshes(combiners);// 将数组中的mesh合并到finalMesh这一个数组中

        obj.GetComponent<MeshFilter>().sharedMesh = finalMesh;// 赋值
        Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
        AssetDatabase.CreateAsset(mesh, "Assets/" + "test" + ".asset"); // 将新的mesh 信息保存到本地
    }
}