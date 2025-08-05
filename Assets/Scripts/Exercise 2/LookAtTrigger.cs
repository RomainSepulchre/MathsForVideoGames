using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    public Transform triggerTf;
    public Transform playerPosTf;

    public float detectionThreshold;

    public bool isDetected;

    //[Header("Variable for my solution")]
    //public Transform originTf;
    //public Transform objToDetectTf;
    //public Transform lookAtTf;

    //public float dot;

    //[Range(0f, 1f)]
    //public float detectionThreshold;

    //public bool isDetected;

    private void OnDrawGizmos()
    {
        GizmoLibrary.Draw2dOrthonormedSystem(2.5f,2.5f);

        Vector2 triggerPos = triggerTf.position;
        Vector2 playerPos = playerPosTf.position;
        Vector2 playerLookDir = playerPosTf.right;

        Vector2 playerToTriggerDir = (triggerPos - playerPos).normalized;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(playerPos, playerPos + playerToTriggerDir);

        float dot = Vector2.Dot(playerToTriggerDir, playerLookDir);

        isDetected = dot >= detectionThreshold;

        Gizmos.color = isDetected  ? Color.green : Color.red;
        Gizmos.DrawLine(playerPos, playerPos + playerLookDir);
    }

    private void PersonalExerciseResolution()
    {
        //// Only works when origin is 0,0
        //Vector2 lookAt = lookAtTf.position;
        //Vector2 origin = originTf.position;
        //Vector2 otherObj = objToDetectTf.position;

        //Vector2 lookAtDirection = lookAt.normalized;
        //Vector2 otherObjDirection = otherObj.normalized;

        //dot = Vector2.Dot(lookAtDirection, otherObjDirection);
        //isDetected = dot >= detectionThreshold;

        //Gizmos.color = isDetected ? Color.green : Color.red;
        //Gizmos.DrawLine(origin, lookAtDirection);

        //Gizmos.color = Color.white;
        //Gizmos.DrawLine(origin, otherObj);
    }

}
