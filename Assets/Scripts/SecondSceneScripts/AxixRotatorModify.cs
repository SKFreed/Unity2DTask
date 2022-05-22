using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AxixRotatorModify : MonoBehaviour
{
    private enum Side
    {
        Left = -1,
        Right = 1
    }

    private Vector2 _one;
    private Vector2 _two;
    private Transform _thisTransform;

    private Camera _camera;
    public int countClick;
    private float z;
    public int click = 0;

    private void Start()
    {
        _one = Vector2.right;
        _camera = Camera.main;
        _thisTransform = transform;
    }

    private void Update()
    {
        if (click == 0)
        {
            transform.localScale = new Vector2(GetValueX(), 1);
            Rotator();
        }
        else if (click != 0)
        {
            Rotator();
        }
        if (Input.GetMouseButtonDown(0) && click < 2)
        {
            click++;
        }
    }

    private float GetValueZ()
    {
        _two = _camera.ScreenToWorldPoint(Input.mousePosition) - _thisTransform.position;
        float scalarComposition = _one.x * _two.x + _one.y * _two.y;
        float mudelesComposition = _one.magnitude * _two.magnitude;
        float division = scalarComposition / mudelesComposition;
        float angle = Mathf.Acos(division) * Mathf.Rad2Deg * (int)GetSide();
        return angle;
    }
    private float GetValueX()
    {
        _two = _camera.ScreenToWorldPoint(Input.mousePosition) - _thisTransform.position;
        float scalarComposition = _one.x * _two.x + _one.y * _two.y;
        float mudelesComposition = _one.magnitude * _two.magnitude;
        float division = scalarComposition / mudelesComposition;
        return mudelesComposition;
    }
    private void Rotator()
    {
        z = GetValueZ();
        if (countClick == 0)
        {
            _thisTransform.rotation = Quaternion.Euler(0, 0, z);
        }
        if (countClick == 0 && this.name == "AxisXHorizontal")
        {
            _thisTransform.rotation = Quaternion.Euler(-90, 0, z);
        }

        if (this.name == "AxisY"  && countClick == 1)
        {
            _thisTransform.GetChild(0).rotation = Quaternion.Euler(0, 0, z);
            _thisTransform.rotation = _thisTransform.GetChild(0).rotation;
        }
        if (this.name == "AxisYHorizontal" && countClick == 1)
        {
            _thisTransform.GetChild(0).rotation = Quaternion.Euler(-90, 0, z);
            _thisTransform.rotation = _thisTransform.GetChild(0).rotation;
        }

        if (Input.GetMouseButtonDown(0) && countClick < 2)
        {
            countClick++;
        }
    }

    private Side GetSide()
    {
        Side side = Side.Right;
        if (_two.y <= _one.y)
            side = Side.Left;
        return side;
    }

    private void OnDrawGizmos()
    {
        if (_thisTransform != null)
        {
            Gizmos.DrawLine(_thisTransform.position, _one * 10);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_thisTransform.position, _camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
