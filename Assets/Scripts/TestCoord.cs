using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TestCoord : MonoBehaviour
{
    public Transform X0Y0;
    public Transform X1;
    public Transform Y1;

    public List<Point> Points = new List<Point>();

    public float XRange;
    public float YRange;

    public float XPoint;
    public float YPoint;

    private float progress;
    public float speed;

    [Range(0f, 1f)]
    private float tx;
    [Range(0f, 1f)]
    private float ty;

    private Vector3 begin;
    private Vector3 end;

    private float xx;
    private float yy;
    private int i;

    private bool _button;
    public TextMeshProUGUI _buttonText;
    public Button button;
    public Toggle toggle;
    


    private void Start()
    {
        xx = 100f / XRange / 100f;
        yy = 100f / YRange / 100f;

        tx = XPoint * xx;
        ty = YPoint * yy;
        i = 0;
        begin = X0Y0.position;
        InputSave.SetTestCoord(this);        
    }

    private void Update()
    {
        if (_button == true)
        {
            MoveCube();
        }
    }
    public void MoveCube()
    {
        Vector3 X = Coord.GetX(X0Y0.position, X1.position + (X1.position - X0Y0.position), tx);
        Vector3 Y = Coord.GetY(X0Y0.position, Y1.position + (Y1.position - X0Y0.position), ty);
        end = Coord.GetPoint(X, Y);

        transform.position = Vector3.MoveTowards(begin, end, progress);
        progress += speed / 1000f;
        button.interactable = false;
        if (Vector3.Distance(transform.position, end) < 0.02f)
        {
            Debug.Log("Достиг цели");
            begin = end;
            
            progress = 0;
            if (i < Points.Count)
            {                
                tx = Points[i].x * xx;
                ty = Points[i].y * yy;
                if (toggle.isOn == true)
                {
                    i++;                    
                }
                button.interactable = true;
            }
        }
    }
    public void InfoButton()
    {
        _button = true;

        if (toggle.isOn == false)
        {
            i++;
        }   
        button.interactable = false;
    }

}
