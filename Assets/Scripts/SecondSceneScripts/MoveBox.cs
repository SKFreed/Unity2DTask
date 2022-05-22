using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MoveBox : MonoBehaviour
{
    [SerializeField] private Transform X0;
    [SerializeField] private Transform Y0;
    [SerializeField] private Transform X1;
    [SerializeField] private Transform Y1;
    [SerializeField] private Toggle _all;

    public List<Vector2> _vectorPoints;
    
    [SerializeField] private float _speed;
    [SerializeField] private MoveBox _cube;

    private Vector3 _end;
    private int _index;
    private bool _go;

    private void Update()
    {
        if (_cube != null)
        {
            _vectorPoints = _cube._vectorPoints;
        }
        if (_go)
        {
            MovementCube();
        }

    }
    private void MovementCube()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPosition(_index), _speed * Time.deltaTime);
        if (Vector3.Distance(_end, transform.position) < 0.02f && _vectorPoints.Count > _index + 1)
        {
            _index++;
            if (_all.isOn == false)
            {
                _go = false;
            }
        }
    }
    private Vector3 NextPosition(int index)
    {
        if (_vectorPoints.Count > 0 )
        {
            _end = X1.position * _vectorPoints[index].x + Y1.position * _vectorPoints[index].y;
            return _end;
        }
        else
        {
            return Vector3.zero;
        }
    }
    public void CanMove()
    {
        _go = true;
    }

}
   