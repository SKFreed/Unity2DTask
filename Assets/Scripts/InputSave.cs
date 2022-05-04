using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InputSave : MonoBehaviour
{
    public List<TMP_InputField> input;
    private static TestCoord test;
    private float _inputDown = 0.5f;

    public static void SetTestCoord( TestCoord testcoord)
    {
        test = testcoord;
    }
    public void SetInput()
    {            
        for(int i = 0; i < input.Count; i +=2 )
        {
            float x;
            float y;
            try
            {
                 x = float.Parse(input[i].text);
                 y = float.Parse(input[i + 1].text);
                if (test != null)
                {
                    Debug.Log(x + " " + y);
                    Point point;
                    point = ScriptableObject.CreateInstance<Point>();
                    point.x = x;
                    point.y = y;
                    test.Points.Add(point);
                }
            }
            catch 
            { 
                Debug.Log("Неудалось прочиать координаты");                
            }
            
        }
    }
    public void AddInput()
    {
        TMP_InputField addX = Instantiate(input[0], input[0].transform.position + new Vector3(0, -_inputDown, 0), input[0].transform.rotation, input[0].transform.parent);
        TMP_InputField addY = Instantiate(input[1], input[1].transform.position + new Vector3(0, -_inputDown, 0), input[1].transform.rotation, input[1].transform.parent);
        input.Add(addX);
        input.Add(addY);
        _inputDown += 0.5f;
    }
}
