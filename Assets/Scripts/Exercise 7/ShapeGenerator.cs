using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    private enum Shapes
    {
        EquilateralTriangle = 3,
        Square = 4,
        Pentagon = 5,
        Hexagon = 6,
        Heptagon = 7,
        Octagon = 8,
        Nonagon = 9,
        Decagon = 10,
    }

    [SerializeField] private Shapes shape = Shapes.EquilateralTriangle;

    [Range(1,5)]
    [SerializeField] private int density;

    private const float Tau = 6.28318530718f;

    private Vector2 AngleToDir(float angleRad)
    {
        return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float DirToAngle(Vector2 dir)
    {
        return Mathf.Atan2(dir.y, dir.x);
    }

    private void OnDrawGizmos()
    {
        DrawShape(shape, density);
    }

    private void DrawShape(Shapes _shape, int _density)
    {
        List<Vector2> points = new List<Vector2>();
        int sides = (int)_shape;

        for (int i = 0; i < sides; i++)
        {
            Vector2 pos = AngleToDir(i * Tau/sides);
            
            points.Add(pos);
            Debug.Log($"DRAW POINT {i+1}/{sides} at Pos {pos}");
        }

        for (int j = 0; j < points.Count; j++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(points[j], 0.15f);

            float colValue = (float)(j + 1) / points.Count; 
            Gizmos.color = new Color(colValue, colValue, colValue);

            Gizmos.DrawLine(points[j], points[(j + _density) % points.Count]);

            Debug.Log($"DRAW POINT {j+1}/{sides} witj Col {Gizmos.color}");
        }
    }
}
