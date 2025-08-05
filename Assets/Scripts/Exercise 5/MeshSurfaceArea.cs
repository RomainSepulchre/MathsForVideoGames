using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSurfaceArea : MonoBehaviour
{
    [Header("Custom Mesh")]
    public MeshFilter meshFilter;
    public float meshSurfaceArea;

    [Header("Predefined Mesh")]
    public MeshFilter quadMeshFilter;
    public float quadMeshSurfaceArea;
    [Space]
    public MeshFilter cubeMeshFilter;
    public float cubeMeshSurfaceArea;
    [Space]
    public MeshFilter planeMeshFilter;
    public float planeMeshSurfaceArea;
    [Space]
    public MeshFilter sphereMeshFilter;
    public float sphereMeshSurfaceArea;
    [Space]
    public MeshFilter capsuleMeshFilter;
    public float capsuleMeshSurfaceArea;
    [Space]
    public MeshFilter cylinderMeshFilter;
    public float cylinderMeshSurfaceArea;

    private void OnValidate ()
    {
        meshSurfaceArea = GetMeshSurfaceArea(meshFilter.sharedMesh);
        quadMeshSurfaceArea = GetMeshSurfaceArea(quadMeshFilter.sharedMesh);
        cubeMeshSurfaceArea = GetMeshSurfaceArea(cubeMeshFilter.sharedMesh);
        planeMeshSurfaceArea = GetMeshSurfaceArea(planeMeshFilter.sharedMesh);
        sphereMeshSurfaceArea = GetMeshSurfaceArea(sphereMeshFilter.sharedMesh);
        capsuleMeshSurfaceArea = GetMeshSurfaceArea(capsuleMeshFilter.sharedMesh);
        cylinderMeshSurfaceArea = GetMeshSurfaceArea(cylinderMeshFilter.sharedMesh);
    }

    private float GetMeshSurfaceArea(Mesh m)
    {
        float meshSurface = 0;

        int[] triangles = m.triangles;
        Vector3[] vertices = m.vertices;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 pointA = vertices[triangles[i]];
            Vector3 pointB = vertices[triangles[i+1]];
            Vector3 pointC = vertices[triangles[i+2]];

            float triangleSurface = Vector3.Cross((pointB - pointA), (pointC - pointA)).magnitude / 2;
            
            meshSurface += triangleSurface;
        }

        return meshSurface;
    }
}
