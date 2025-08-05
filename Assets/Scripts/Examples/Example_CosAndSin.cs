using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_CosAndSin : MonoBehaviour
{
    private const float Tau = 2 * Mathf.PI;

    public int circleResolution = 6;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < circleResolution; i++)
        {
            float t = i / (float)circleResolution;
            float angRad = t * Tau;

            float xPos = Mathf.Cos(angRad);
            float yPos = Mathf.Sin(angRad);

            Vector2 pos = new Vector2(xPos, yPos);

            Gizmos.DrawSphere(pos, 0.05f);
        }
    }
}
