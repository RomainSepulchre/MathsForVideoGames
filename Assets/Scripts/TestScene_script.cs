using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene_script : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float dotAB;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector2.zero, pointA.position);
        Gizmos.DrawLine(Vector2.zero, pointB.position);

        GizmoLibrary.Draw2dOrthonormedSystem();
        GizmoLibrary.Draw2dDotProduct(pointB.position.normalized, pointA.position, out dotAB);
    }
}
