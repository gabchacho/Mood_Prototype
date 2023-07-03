using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColoringScript : MonoBehaviour
{

    /*

private void Awake()
{
    //creates a new quad mesh for point of pens
    Mesh mesh = new Mesh();


    Vector3[] vertices = new Vector3[4];
    Vector2[] uv = new Vector2[4];
    int[] triangles = new int[6];

    //location of vertices that make up the mesh for coloring
    vertices[0] = new Vector3(-1, 1);
    vertices[1] = new Vector3(-1, -1);
    vertices[2] = new Vector3(1, -1);
    vertices[3] = new Vector3(1, 1);

    //creates  new uv for selected color
    uv[0] = Vector2.zero;
    uv[1] = Vector2.zero;
    uv[2] = Vector2.zero;
    uv[3] = Vector2.zero;

    triangles[0] = 0;
    triangles[1] = 3;
    triangles[2] = 1;

    triangles[3] = 1;
    triangles[4] = 3;
    triangles[5] = 2;

    mesh.vertices = vertices;
    mesh.uv = uv;
    mesh.triangles = triangles;
    mesh.MarkDynamic();
    GetComponent<MeshFilter>().mesh = mesh;

    // if left click is held down the uv for the coloring will track it

    if (Input.GetMouseButton(0))
    {
        Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
        Vector2[] uv = new Vector2[mesh.uv.Length + 2];
        int[] triangles = new int[mesh.triangles.Length + 6];

        mesh.vertices.CopyTo(vertices, 0);
        mesh.uv.CopyTo(uv, 0);
        mesh.triangles.CopyTo(triangles, 0);

        int vIndex = vertices.Length - 4;
        int vIndex0 = vIndex + 0;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;


        Vector3 mouseForward = (UtilsClass.GetMouseWorldPosition() - lastMousePosition).normalized;
        Vector2 normal2D = new Vector3(0, 0, -1f);
        float lineThickness = 1f;
        Vector3 newVectexUp = UtilsClass.GetMouseWorldPosition() + Vector3.Cross(mouseForward, normal2D) * lineThickness;
        Vector3 newVectexDown = UtilsClass.GetMouseWorldPosition() + Vector3.Cross(mouseForward, normal2D * -1f) * lineThickness;

    }
        */


}






