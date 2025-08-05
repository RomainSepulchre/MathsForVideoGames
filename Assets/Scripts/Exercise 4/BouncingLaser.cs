using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingLaser : MonoBehaviour
{
    public int maxBounceCount = 3;

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        Vector3 dir = transform.forward;
       
        void DrawDir(Vector3 position, Vector3 direction) => Gizmos.DrawLine(position, position + direction);

        RaycastHit[] hits = new RaycastHit[maxBounceCount];
        Vector3[] positions = new Vector3[maxBounceCount];
        Vector3[] directions = new Vector3[maxBounceCount];

        positions[0] = pos;
        directions[0] = dir;

        for (int i = 0; i < maxBounceCount; i++)
        {
            if (Physics.Raycast(positions[i], directions[i], out hits[i]))
            {
                Vector3 hitPos = hits[i].point;
                Vector3 hitNormal = hits[i].normal;
                int iNext = i + 1;

                if (iNext < maxBounceCount)
                {
                    positions[iNext] = hitPos;
                    directions[iNext] = GetReflectedDirection(directions[i], hitNormal);
                }
                else
                {
                    //Draw end ray
                    Vector3 lastReflectedDir = GetReflectedDirection(directions[i], hitNormal);
                    Gizmos.color = Color.gray;
                    DrawDir(hitPos, lastReflectedDir/2);
                }

                //Draw Ray
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(positions[i], hitPos);

                //Draw hitNormal
                Gizmos.color = Color.cyan;
                DrawDir(hitPos, hitNormal/4);
            }
            else
            {
                Gizmos.color = Color.yellow;
                DrawDir(positions[i], directions[i]*10);
                break;
            }
        }
    }

    private Vector3 GetReflectedDirection(Vector3 initialDirection, Vector3 normal)
    {
        float dot = Vector3.Dot(normal, initialDirection);
        Vector3 inversedNormal = normal * dot;
        Vector3 reflectedDir = initialDirection - (inversedNormal * 2);

        return reflectedDir;
    }
}
