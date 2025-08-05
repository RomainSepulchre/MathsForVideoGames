using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    public int maxBounceCount = 3;
    public Transform initialTf;
    [Range(0.1f,5f)]
    public float speed = 1f;

    private Vector3 pos;
    private Vector3 dir;

    private RaycastHit[] hits;
    private Vector3[] positions;
    private Vector3[] directions;

    private int step;
    private float timeElapsed;
    private float lerpDuration;

    void Start()
    {
        transform.position = initialTf.position;
        transform.rotation = initialTf.rotation;

        pos = initialTf.position;
        dir = initialTf.forward;

        hits = new RaycastHit[maxBounceCount];
        positions = new Vector3[maxBounceCount];
        directions = new Vector3[maxBounceCount];

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
            }
        }

        step = 0;
        timeElapsed = 0f;
        lerpDuration = Vector3.Distance(positions[step], hits[step].point);
    }

    void Update()
    {
        int nextStep = step + 1;
        transform.position = Vector3.Lerp(positions[step], hits[step].point, (timeElapsed*speed) / lerpDuration);
        timeElapsed += Time.deltaTime;

        if (transform.position == hits[step].point)
        {  
            timeElapsed = 0;

            if (nextStep < maxBounceCount)
            {
                transform.forward = directions[nextStep];
                lerpDuration = Vector3.Distance(positions[nextStep], hits[nextStep].point);
                step++; 
            }
            else
            {
                step = 0;
                transform.forward = directions[step];
                lerpDuration = Vector3.Distance(positions[step], hits[step].point);
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
