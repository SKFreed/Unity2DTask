using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class InputSave : MonoBehaviour
{
    public List<TMP_InputField> input;
    private static TestCoord test;
    private float _inputDown = 0.5f;
    public Item item;

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
                string xstring = input[i].text;
                string ystring = input[i+1].text;
                /*Item tmpItem = MonoBehaviour.Instantiate<Item>(item);
                tmpItem.Add(xstring, ystring);*/
                 x = float.Parse(xstring);
                 y = float.Parse(ystring);
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
            catch (Exception ex)
            { 

                Debug.Log("Неудалось прочиать координаты");     
                Debug.Log(ex.Message.ToString());
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
    public void DelInput()
    {
       /* for (int i = 0; i < input.Count; i += 2)
        {
            if(i == 0)
            {
                
                input[0].text = "";
                input[1].text = "";
            }
            else
            {
               // Destroy(input[i]);
               
            }
        }*/
    }
   
    public void LoadFromJson()
    {
        item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.streamingAssetsPath + "/DataJson.json"));        
        for (int i = 2; i < item.values.Count; i += 2)
        {
            float x;
            float y;
            try
            {                          
                x = item.values[i];
                y = item.values[i + 1];
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
            catch (Exception ex)
            {
                Debug.Log("Неудалось прочиать координаты из файла");
                Debug.Log(ex.Message.ToString());
            }

        }
    }
    public void SaveToJson()
    {       
        List<float> list2 = new List<float>();
        for (int i = 0; i < test.Points.Count; i++)
        {
            list2.Add(test.Points[i].x);
            list2.Add(test.Points[i].y);
        }
        item = new Item(list2);


        File.WriteAllText(Application.streamingAssetsPath + "/DataJson.json", JsonUtility.ToJson(item));
    }
    [System.Serializable]
    public class Item 
    {        
        public List<float> values;
        public Item(List<float> val)
        {
            values = val;
        }
    }
}
