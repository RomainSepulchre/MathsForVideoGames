using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Example_CrossProduct : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawDir(Vector3 p, Vector3 dir) => Handles.DrawLine(p, p + dir);

        if (Physics.Raycast(headPos, lookDir, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up, lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up).normalized;

            Handles.color = Color.white;
            Handles.DrawLine(headPos, hitPos);
            Handles.color = Color.green;
            DrawDir(hitPos, up);
            Handles.color = Color.red;
            DrawDir(hitPos, right);
            Handles.color = Color.blue;
            DrawDir(hitPos, forward);
        }
        else
        {
            Handles.color = Color.black;
            DrawDir(headPos, lookDir);
        }

    }
}
