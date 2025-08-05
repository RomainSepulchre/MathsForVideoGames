using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    private Transform triggerOrigin;
    public Transform objToDetect;
    public bool isInside;

    public float triggerRadius;

    private void OnDrawGizmos()
    {
        GizmoLibrary.Draw2dOrthonormedSystem(5, 5);
        Vector2 a = transform.position;
        Vector2 b = objToDetect.position;

        float dist = Vector2.Distance(a, b);
        isInside = dist < triggerRadius;

        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(a, Vector3.forward , triggerRadius);  
    }
}
