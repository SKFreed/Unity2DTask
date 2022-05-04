using UnityEngine;

public class Coord : MonoBehaviour
{
    public static Vector3 GetX(Vector3 X0Y0, Vector3 X1, float tx)
    {
        Vector3 X0X1 = Vector3.Lerp(X0Y0, X1, tx);
        return X0X1;
    }
    public static Vector3 GetY(Vector3 X0Y0, Vector3 Y1, float ty)
    {
        Vector3 Y0Y1 = Vector3.Lerp(X0Y0, Y1, ty);
        return Y0Y1;
    }
    public static Vector3 GetPoint(Vector3 X, Vector3 Y)
    {
        Vector3 point = Vector3.Lerp(X, Y, 0.5f);
        return point;
    }
}
