using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransform : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

    [Header("Transform Value")]
    public Vector2 bPos_RealLocal;
    public Vector2 bPos_RealWorld;
    [Header("Calculated Value")]
    public Vector2 bPos_WorldToLocal_Calculated;
    public Vector2 bPos_LocalToWorld_Calculated;

    [Header("Space Point | Yellow=local / Blue=World")]
    public Vector2 localSpacePoint;
    public Vector2 worldSpacePoint;

    private void OnDrawGizmos()
    {
        // Define the base value needed
        Vector2 aPos = pointA.position;
        Vector2 a2dForward = pointA.right;
        Vector2 a2dUp = pointA.up;

        Vector2 bPos = pointB.position;
        Vector2 b2dForward = pointB.right;
        Vector2 b2dUp = pointA.up;

        //Draw the world space orthonormed system
        GizmoLibrary.Draw2dOrthonormedSystem(10, 10);
        
        // Draw A Forward and Up axis
        GizmoLibrary.Draw2dForward(pointA);
        GizmoLibrary.Draw2dUp(pointA);
        // Draw B Forward and Up axis
        GizmoLibrary.Draw2dForward(pointB);
        GizmoLibrary.Draw2dUp(pointB);
        // Draw the local orthonormed system for A
        GizmoLibrary.Draw2dCrossWithRotation(pointA, 2f);
        //GizmoLibrary.Draw2dCrossWithRotation(pointB, 1f);

        // Reference Positions
        bPos_RealLocal = pointB.localPosition;
        bPos_RealWorld = pointB.position;

        //Calculated Positions
        bPos_WorldToLocal_Calculated = FromWorldToLocalPos(pointA, pointB.position);
        bPos_LocalToWorld_Calculated = FromLocalToWorldPos(pointA, pointB.localPosition);

        // LocalToWorld: Sphere positionned using a given local position translated into a a world position
        Vector2 localSpherePos = FromLocalToWorldPos(pointA, localSpacePoint);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(localSpherePos, 0.1f);

        // WorldToLocal: Sphere positionned using a given local position translated into a a world position
        Vector2 worldSpherePos = FromWorldToLocalPos(pointA, worldSpacePoint);
        Vector2 WorldPos = FromLocalToWorldPos(pointA, worldSpherePos); // Need to translate back to WorldPos to position the point correctly
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(WorldPos, 0.1f);

    }

    // Give a world position for a specified local position
    private Vector2 FromLocalToWorldPos(Transform localOrigin, Vector2 bPos_Local)
    {      
        Vector2 originPos_World = localOrigin.position;
        Vector2 origin2dForward = localOrigin.right;
        Vector2 origin2dUp = localOrigin.up;

        Vector2 originToB_World_xPos = origin2dForward * bPos_Local.x;
        Vector2 originToB_World_yPos = origin2dUp * bPos_Local.y;

        Vector2 originToB_World = originToB_World_xPos + originToB_World_yPos;

        Vector2 worldPosition = originPos_World + originToB_World;
        return worldPosition;
    }

    // Give a local position for a specified world position
    private Vector2 FromWorldToLocalPos(Transform localOrigin, Vector2 bPos_World)
    {
        Vector2 originPos_World = localOrigin.position;
        Vector2 originToB_World = bPos_World - originPos_World;

        float originToB_Local_x = Vector2.Dot(originToB_World, localOrigin.right);
        float originToB_Local_y = Vector2.Dot(originToB_World, localOrigin.up);

        Vector2 localBPosition = new Vector2(originToB_Local_x, originToB_Local_y);
        return localBPosition;
    }
}
