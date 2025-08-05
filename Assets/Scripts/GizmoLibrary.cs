using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GizmoLibrary
{
    private static Color redDark = new Color(0.5f, 0f, 0f);
    private static Color redLight = new Color(1f,0.5f,0.5f);
    private static Color greenDark = new Color(0f, 0.5f, 0f);
    private static Color greenLight = new Color(0.5f, 1f, 0.5f);

    /// <summary>
    /// Draw the 2D Forward Vector of an object
    /// </summary>
    /// <param name="tf">Transform of the object on which the 2D Forward vector must be drawn</param>
    /// <param name="lenght">Optional: Set the length of the forward vector line (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: red)</param>
    public static void Draw2dForward(Transform tf, float lenght = 1f, Color? col = null)
    {
        Vector2 pos = tf.position;
        Vector2 pos2dForward = tf.right;
        Vector2 endPos = pos + (pos2dForward * (lenght));

        // Arrow Position
        float arrowScaleFactor = 0.1f;
        Vector2 topArrowEndPos = new Vector2(endPos.x - arrowScaleFactor, endPos.y + arrowScaleFactor);
        Vector2 bottomArrowEndPos = new Vector2(endPos.x - arrowScaleFactor, endPos.y - arrowScaleFactor);

        Gizmos.color = col ?? Color.red;
        Gizmos.DrawLine(pos, endPos);
        Gizmos.DrawLine(endPos, topArrowEndPos);
        Gizmos.DrawLine(endPos, bottomArrowEndPos);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw the 2D Up Vector of an object
    /// </summary>
    /// <param name="tf">Transform of the object on which the 2D Up vector must be drawn</param>
    /// <param name="lenght">Optional: Set the length of the up vector line (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: green)</param>
    public static void Draw2dUp(Transform tf, float lenght = 1f, Color? col = null)
    {
        Vector2 pos = tf.position;
        Vector2 pos2dUp = tf.up;
        Vector2 endPos = pos + (pos2dUp * (lenght));

        float arrowScaleFactor = 0.1f;
        Vector2 topArrowEndPos = new Vector2(endPos.x + arrowScaleFactor, endPos.y - arrowScaleFactor);
        Vector2 bottomArrowEndPos = new Vector2(endPos.x - arrowScaleFactor, endPos.y - arrowScaleFactor);

        Gizmos.color = col ?? Color.green;
        Gizmos.DrawLine(pos, endPos);
        Gizmos.DrawLine(endPos, topArrowEndPos);
        Gizmos.DrawLine(endPos, bottomArrowEndPos);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw the 2D direction of the object position vector
    /// </summary>
    /// <param name="position">Position vector of the object on which the 2D direction must be drawn</param>
    /// <param name="lenght">Optional: Set the length of the vector direction line (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: white)</param>
    public static void Draw2dDirection(Vector2 position, float lenght = 1.0f, Color? col = null)
    {
        Vector2 endPosition = position + (position.normalized*lenght);

        Gizmos.color = col ?? Color.white;
        Gizmos.DrawLine(position, endPosition);

        //Color reset
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw the 2D direction of the object position vector
    /// </summary>
    /// <param name="tf">Transform of the object on which the 2D direction must be drawn</param>
    /// <param name="lenght">Optional: Set the length of the vector direction line (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: white)</param>
    public static void Draw2dDirection(Transform tf, float lenght = 1.0f, Color? col = null)
    {
        Vector2 position = tf.position;
        Vector2 endPosition = position + (position.normalized*lenght);

        Gizmos.color = col ?? Color.white;
        Gizmos.DrawLine(position, endPosition);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw the calculation of a Dot Product between "vectorA" and "vectorB"
    /// </summary>
    /// <param name="vectorA">First vector of the Dot Product</param>
    /// <param name="vectorB">Second vector of the Dot Product</param>
    /// <param name="origin">Optional: Origin position where the gizmo must be drawn (Default: (0,0))</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: blue=VectorA and B, black=Dot Product Line, grey=Dot Product position)</param>
    public static void Draw2dDotProduct(Vector2 vectorA, Vector2 vectorB, Vector2 origin = default, Color? col = null)
    {
        float dotAB = Vector2.Dot(vectorA, vectorB);

        Gizmos.color = col ?? Color.blue;
        Gizmos.DrawLine(origin, origin + (vectorA.normalized * dotAB));
        Gizmos.DrawLine(origin, origin + (vectorB.normalized * dotAB));

        Gizmos.color = col ?? Color.black;
        Gizmos.DrawLine(origin + (vectorA.normalized * dotAB), origin + (vectorB.normalized * dotAB));

        Gizmos.color = col ?? Color.grey;
        GizmoLibrary.Draw2dCrossFixed(origin + (vectorB.normalized * dotAB), 0.25f);

        //Color reset
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw the calculation of a Dot Product between "vectorA" and "vectorB"
    /// </summary>
    /// <param name="vectorA">First vector of the Dot Product</param>
    /// <param name="vectorB">Second vector of the Dot Product</param>
    /// <param name="dotAB">Out: the result of the dot product</param>
    /// <param name="origin">Optional: Origin position where the gizmo must be drawn (Default: (0,0))</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: blue=VectorA and B, black=Dot Product Line, grey=Dot Product position)</param>
    public static void Draw2dDotProduct(Vector2 vectorA, Vector2 vectorB,out float dotAB, Vector2 origin = default, Color? col = null)
    {
        dotAB = Vector2.Dot(vectorA, vectorB);

        Gizmos.color = col ?? Color.blue;
        Gizmos.DrawLine(origin, origin + (vectorA * dotAB));
        Gizmos.DrawLine(origin, origin + vectorB);

        Gizmos.color = col ?? Color.black;
        Gizmos.DrawLine(origin + (vectorA * dotAB), origin + vectorB);

        Gizmos.color = col ?? Color.grey;
        GizmoLibrary.Draw2dCrossFixed(origin + (vectorA * dotAB), 0.25f);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw a cross aligned on the world space (not affected by the rotation of the object)
    /// </summary>
    /// <param name="position">Position where the cross must be drawn</param>
    /// <param name="size">Optional: Size of the cross (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: grey)</param>
    public static void Draw2dCrossFixed(Vector2 position, float size = 1f, Color? col = null)
    {
        Vector2 xAxisStart = new Vector2(position.x - (size/2), position.y);
        Vector2 xAxisEnd = new Vector2(position.x + (size / 2), position.y);
        Vector2 yAxisStart = new Vector2(position.x, position.y - (size / 2));
        Vector2 yAxisEnd = new Vector2(position.x, position.y + (size / 2));

        Gizmos.color = col ?? Color.grey;
        Gizmos.DrawLine(xAxisStart, xAxisEnd);
        Gizmos.DrawLine(yAxisStart, yAxisEnd);

        //Color reset
        Gizmos.color = Color.white;
    }


    //--


    /// <summary>
    /// Draw a cross aligned on the local space of the object (affected by the rotation of the object)
    /// </summary>
    /// <param name="tf">Transform of the object on which the cross must be drawn</param>
    /// <param name="size">Optional: Size of the cross (Default: 1f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: red=xAxis, green=yAxis)</param>
    public static void Draw2dCrossWithRotation(Transform tf, float size=1.0f, Color? col = null)
    {
        Vector2 pos = tf.position;
        Vector2 pos2dForward = tf.right;
        Vector2 pos2dUp = tf.up;

        Vector2 xAxisStart = pos - (pos2dForward * (size / 2)) ;
        Vector2 xAxisEnd = pos + (pos2dForward * (size / 2));
        Vector2 yAxisStart = pos - (pos2dUp * (size / 2));
        Vector2 yAxisEnd = pos + (pos2dUp * (size / 2));

        Gizmos.color = col ?? Color.red;
        Gizmos.DrawLine(xAxisStart, xAxisEnd);
        Gizmos.color = col ?? Color.green;
        Gizmos.DrawLine(yAxisStart, yAxisEnd);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw a 2d Triangle based on 3 positions (a, b and c)
    /// </summary>
    /// <param name="aPos">First triangle point position</param>
    /// <param name="bPos">Second triangle point position</param>
    /// <param name="cPos">Third triangle point position</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: grey)</param>
    public static void Draw2dTriangle(Vector2 aPos, Vector2 bPos, Vector2 cPos, Color? col = null)
    {
        Gizmos.color = col ?? Color.grey;
        Gizmos.DrawLine(aPos, bPos);
        Gizmos.DrawLine(bPos, cPos);
        Gizmos.DrawLine(aPos, cPos);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw a 2d Right-Angled Triangle based on 2 positions (a, b), the third point being (a.x, b.y)
    /// </summary>
    /// <param name="aPos">First triangle point position</param>
    /// <param name="bPos">Second triangle point position</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: grey)</param>
    public static void Draw2dRightAngledTriangleBetweenPoints(Vector2 aPos, Vector2 bPos, Color? col = null)
    {
        Vector2 thirdPoint = new Vector2(aPos.x, bPos.y);

        Gizmos.color = col ?? Color.grey;
        Gizmos.DrawLine(aPos, bPos);
        Gizmos.DrawLine(bPos, thirdPoint);
        Gizmos.DrawLine(aPos, thirdPoint);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw a 2D Orthonormed System at the origin of the World Space
    /// </summary>
    /// <param name="xSize">Optional: Size of the X Axis (Default: 5f)</param>
    /// <param name="ySize">Optional: Size of the Y Axis (Default: 5f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: redDark=xAxis, greenDark=yAxis)</param>
    public static void Draw2dOrthonormedSystem(float xSize=5f, float ySize=5f, Color? col = null)
    {
        Vector2 xAxisStart = new Vector2((xSize/2) * -1, 0);
        Vector2 xAxisEnd = new Vector2((xSize/2), 0);

        Vector2 yAxisStart = new Vector2(0, (ySize/2) * -1);
        Vector2 yAxisEnd = new Vector2(0, (ySize/2));

        Gizmos.color = col ?? redDark;
        Gizmos.DrawLine(xAxisStart, xAxisEnd);
        Gizmos.color = col ?? greenDark;
        Gizmos.DrawLine(yAxisStart, yAxisEnd);

        //Color reset
        Gizmos.color = Color.white;
    }


    //---


    /// <summary>
    /// Draw a 2D Orthonormed System at the position (xPos, yPos)
    /// </summary>
    /// <param name="xPos">X Position in the world space of the center of the Orthonormed System</param>
    /// <param name="yPos">Y Position in the world space of the center of the Orthonormed System</param>
    /// <param name="xSize">Optional: Size of the X Axis (Default: 5f)</param>
    /// <param name="ySize">Optional: Size of the Y Axis (Default: 5f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: redDark=xAxis, greenDark=yAxis)</param>
    public static void Draw2dOrthonormedSystemAtPos(float xPos, float yPos, float xSize=5f, float ySize=5f, Color? col = null)
    {
        Vector2 xAxisStart = new Vector2(xPos + ((xSize/2) * -1), yPos);
        Vector2 xAxisEnd = new Vector2(xPos + (xSize/2), yPos);

        Vector2 yAxisStart = new Vector2(xPos, yPos + ((ySize/2) * -1));
        Vector2 yAxisEnd = new Vector2(xPos, yPos + (ySize/2));

        Gizmos.color = col ?? redDark;
        Gizmos.DrawLine(xAxisStart, xAxisEnd);
        Gizmos.color = col ?? greenDark;
        Gizmos.DrawLine(yAxisStart, yAxisEnd);

        //Color reset
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a 2D Orthonormed System at the origin position
    /// <param name="origin">Origin position of the Orthonormed System</param>
    /// <param name="xSize">Optional: Size of the X Axis (Default: 5f)</param>
    /// <param name="ySize">Optional: Size of the Y Axis (Default: 5f)</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: redDark=xAxis, greenDark=yAxis)</param>
    public static void Draw2dOrthonormedSystemAtPos(Vector2 origin, float xSize=5f, float ySize=5f,  Color? col = null)
    {
        Vector2 xAxisStart = new Vector2(origin.x + ((xSize / 2) * -1), origin.y);
        Vector2 xAxisEnd = new Vector2(origin.x + (xSize / 2), origin.y);

        Vector2 yAxisStart = new Vector2(origin.x, origin.y + ((ySize / 2) * -1));
        Vector2 yAxisEnd = new Vector2(origin.x, origin.y + (ySize / 2));

        Gizmos.color = col ?? redDark;
        Gizmos.DrawLine(xAxisStart, xAxisEnd);
        Gizmos.color = col ?? greenDark;
        Gizmos.DrawLine(yAxisStart, yAxisEnd);

        //Color reset
        Gizmos.color = Color.white;
    }

    /// <summary>
    /// Draw a 2D Orthonormed System based on 4 positions (xMin, xMax, yMin, Ymax)
    /// </summary>
    /// <param name="xMin">Position of the minimum value of the X Axis</param>
    /// <param name="xMax">Position of the maximum value of the X Axis</param>
    /// <param name="yMin">Position of the minimum value of the Y Axis</param>
    /// <param name="yMax">Position of the maximum value of the Y Axis</param>
    /// <param name="col">Optional: Set the color of the gizmo (Default: redDark=xAxis, greenDark=yAxis)</param>
    public static void Draw2dOrthonormedSystemAtPos(Vector2 xMin, Vector2 xMax, Vector2 yMin, Vector2 yMax, Color? col = null)
    {
        Gizmos.color = col ?? redDark;
        Gizmos.DrawLine(xMin, xMax);
        Gizmos.color = col ?? greenDark;
        Gizmos.DrawLine(yMin, yMax);

        //Color reset
        Gizmos.color = Color.white;
    }

    public static void DrawCrossProduct(Vector3 a, Vector3 b, Vector3 origin)
    {
        Vector3 CrossProduct = Vector3.Cross(a, b);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(origin, origin + a);
        Gizmos.DrawLine(origin, origin + b);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(origin, origin + CrossProduct);

    }
}
