using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretInstantiation : MonoBehaviour
{
    public float TurretHeight = 1.3f;
    public float GunSeparation = 0.3f;
    public float BarrelLength = 0.8f;

    private void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;
        Matrix4x4 turretToWorld;

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

            //*****************
            // Turret Matrix
            //*****************

            Vector4 matrix_X = new Vector4(right.x, right.y, right.z, 0);
            Vector4 matrix_Y = new Vector4(up.x, up.y, up.z, 0);
            Vector4 matrix_Z = new Vector4(forward.x, forward.y, forward.z, 0);
            Vector4 matrix_Pos = new Vector4(hitPos.x, hitPos.y, hitPos.z, 1);
            turretToWorld = new Matrix4x4(matrix_X, matrix_Y, matrix_Z, matrix_Pos);

            //*****************
            // Bounding box
            //*****************

            Vector3 bottom1 = turretToWorld * new Vector4(1, 0, 1, 1);
            Vector3 bottom2 = turretToWorld * new Vector4(-1, 0, 1, 1);
            Vector3 bottom3 = turretToWorld * new Vector4(-1, 0, -1, 1);
            Vector3 bottom4 = turretToWorld * new Vector4(1, 0, -1, 1);

            Vector3 top1 = turretToWorld * new Vector4(1, 2, 1, 1);
            Vector3 top2 = turretToWorld * new Vector4(-1, 2, 1, 1);
            Vector3 top3 = turretToWorld * new Vector4(-1, 2, -1, 1);
            Vector3 top4 = turretToWorld * new Vector4(1, 2, -1, 1);

            Gizmos.color = Color.yellow;

            //Cube bottom
            Gizmos.DrawLine(bottom1, bottom2);
            Gizmos.DrawLine(bottom2, bottom3);
            Gizmos.DrawLine(bottom3, bottom4);
            Gizmos.DrawLine(bottom4, bottom1);

            //Cube top
            Gizmos.DrawLine(top1, top2);
            Gizmos.DrawLine(top2, top3);
            Gizmos.DrawLine(top3, top4);
            Gizmos.DrawLine(top4, top1);

            //Cube Middle
            Gizmos.DrawLine(bottom1, top1);
            Gizmos.DrawLine(bottom2, top2);
            Gizmos.DrawLine(bottom3, top3);
            Gizmos.DrawLine(bottom4, top4);

            //*****************
            // Turret gizmo
            //*****************
            Vector3 Barrel_1_Start = turretToWorld * new Vector4(GunSeparation/2, TurretHeight, 0, 1);
            Vector3 Barrel_2_Start = turretToWorld * new Vector4((GunSeparation / 2) * -1, TurretHeight, 0, 1);
            Vector3 Barrel_1_End = turretToWorld * new Vector4(GunSeparation / 2, TurretHeight, BarrelLength, 1);
            Vector3 Barrel_2_End = turretToWorld * new Vector4((GunSeparation / 2) * -1, TurretHeight, BarrelLength, 1);

            Gizmos.color = Color.black;
            Gizmos.DrawLine(Barrel_1_Start, Barrel_1_End);
            Gizmos.DrawLine(Barrel_2_Start, Barrel_2_End);
            Gizmos.DrawLine(Barrel_1_Start, Barrel_2_Start);

        }
        else
        {
            Handles.color = Color.black;
            DrawDir(headPos, lookDir);
        }

    }
}
