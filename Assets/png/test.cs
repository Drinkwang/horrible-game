using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class test : MonoBehaviour
{

    public enum Direction
    {
        ClockWise,
        Anti_ClockWise
    }

    public Material mat;

    public Direction direction;

    // Use this for initialization
    void Start()
    {
        switch (direction)
        {
            case Direction.ClockWise:
                DrawCubeWithUV_CloclWise();
                break;
            case Direction.Anti_ClockWise:
                DrawCubeWithUV_Anti_CloclWise();
                break;
        }
    }



    void DrawCubeWithUV_CloclWise()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        //设置顶点
        mesh.vertices = new Vector3[]
        {
            //front
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, 0),
 
            //top
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 0, 1),
 
            //back
            new Vector3(0, 1, 1),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1),
 
            //bottom
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
 
            //left
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0),
 
            //right
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, 0),
        };



        //顺时针看不到正面的，贴图在里面
        mesh.triangles = new int[]
       {
              0,1,2,
              0,2,3,
              4,5,6,
              4,6,7,
              8,9,10,
              8,10,11,
              12,13,14,
              12,14,15,
              16,17,18,
              16,18,19,
              20,21,22,
              20,22,23

       };

        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < uvs.Length; i += 4)
        {
            //正常贴图
            uvs[i] = new Vector2(0, 0);
            uvs[i + 1] = new Vector2(0, 1);
            uvs[i + 2] = new Vector2(1, 1);
            uvs[i + 3] = new Vector2(1, 0);

            //转换贴图
            //uvs[i] = new Vector2(1, 0);
            //uvs[i + 1] = new Vector2(1, 1);
            //uvs[i + 2] = new Vector2(0, 1);
            //uvs[i + 3] = new Vector2(0, 0);
        }
        mesh.uv = uvs;

        //Vector3[] normals = new Vector3[mesh.vertices.Length];
        //for (int i = 0; i < normals.Length; i++)
        //{
        //    if (i < 4)
        //        normals[i] = Vector3.forward;
        //    if (i >= 4 && i < 8)
        //        normals[i] = Vector3.up;
        //    if (i >= 8 && i < 12)
        //        normals[i] = Vector3.back;
        //    if (i >= 12 && i < 16)
        //        normals[i] = Vector3.down;
        //    if (i >= 16 && i < 20)
        //        normals[i] = Vector3.left;
        //    if (i >= 20 && i < 24)
        //        normals[i] = Vector3.right;
        //}
        //mesh.normals = normals;
    }

    void DrawCubeWithUV_Anti_CloclWise()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        //设置顶点
        mesh.vertices = new Vector3[]
        {
            //front
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, 0),
 
            //top
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 0, 1),
 
            //back
            new Vector3(0, 1, 1),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1),
 
            //bottom
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
 
            //left
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0),
 
            //right
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, 0),
        };

        //逆时针看到的很好，但是贴图反了
        mesh.triangles = new int[]
       {
              0,2,1,
              0,3,2,
              4,6,5,
              4,7,6,
              8,10,9,
              8,11,10,
              12,14,13,
              12,15,14,
              16,18,17,
              16,19,18,
              20,22,21,
              20,23,22
       };
#if false
        //六个面贴同一张图片
        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < uvs.Length; i += 4)
        {
            //uvs[i] = new Vector2(0, 0);
            //uvs[i + 1] = new Vector2(0, 1);
            //uvs[i + 2] = new Vector2(1, 1);
            //uvs[i + 3] = new Vector2(1, 0);
            uvs[i] = new Vector2(1, 0);
            uvs[i + 1] = new Vector2(1, 1);
            uvs[i + 2] = new Vector2(0, 1);
            uvs[i + 3] = new Vector2(0, 0);
        }
        mesh.uv = uvs;
#else
        //六个面贴不同的图片
        Vector2[] uvs = sixTexForCube(mesh.vertices);
        mesh.uv = uvs;
#endif
        //法线
        //Vector3[] normals = new Vector3[mesh.vertices.Length];
        //for (int i = 0; i < normals.Length; i++)
        //{
        //    if (i < 4)
        //        normals[i] = Vector3.forward;
        //    if (i >= 4 && i < 8)
        //        normals[i] = Vector3.up;
        //    if (i >= 8 && i < 12)
        //        normals[i] = Vector3.back;
        //    if (i >= 12 && i < 16)
        //        normals[i] = Vector3.down;
        //    if (i >= 16 && i < 20)
        //        normals[i] = Vector3.left;
        //    if (i >= 20 && i < 24)
        //        normals[i] = Vector3.right;
        //}
        //mesh.normals = normals;
    }

    Vector2[] sixTexForCube(Vector3[] verticles)
    {
        Vector2[] uv = new Vector2[verticles.Length];

        float t = 1 / 3f;

        //front
        uv[0] = new Vector2(t, 0);
        uv[1] = new Vector2(t, t);
        uv[2] = new Vector2(0, t);
        uv[3] = new Vector2(0, 0);

        //top
        uv[4] = new Vector2(2 * t, 0);
        uv[5] = new Vector2(2 * t, t);
        uv[6] = new Vector2(t, t);
        uv[7] = new Vector2(t, 0);

        //back
        uv[8] = new Vector2(1, 0);
        uv[9] = new Vector2(1, t);
        uv[10] = new Vector2(2 * t, t);
        uv[11] = new Vector2(2 * t, 0);

        //Bottom
        uv[12] = new Vector2(t, t);
        uv[13] = new Vector2(t, 2 * t);
        uv[14] = new Vector2(0, 2 * t);
        uv[15] = new Vector2(0, t);

        //left
        uv[16] = new Vector2(2 * t, t);
        uv[17] = new Vector2(2 * t, 2 * t);
        uv[18] = new Vector2(t, 2 * t);
        uv[19] = new Vector2(t, t);

        //right
        uv[20] = new Vector2(1, t);
        uv[21] = new Vector2(1, 2 * t);
        uv[22] = new Vector2(2 * t, 2 * t);
        uv[23] = new Vector2(2 * t, t);

        return uv;
    }
}

