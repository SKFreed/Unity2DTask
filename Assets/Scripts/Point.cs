using UnityEngine;

[CreateAssetMenu(fileName = "PointData", menuName = "Points/Point")]
public class Point : ScriptableObject
{
    public float x { get; set; }
    public float y { get; set; }
   
}
