using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _startPosX, _startPosY;
    public Field _field;
    protected PointField _curPoint;
    protected PointField _prevPoint;
    
    public void Start()
    {
        _curPoint = _field.GetMatrixPoint(_startPosX, _startPosY);
        transform.position = _field.GetMatrixPoint(_startPosX, _startPosY).transform.position;

        GameInfo.init.NextStepAction += Move;
    }

    public void OnDisabled()
    {
        GameInfo.init.NextStepAction -= Move;
    }
    
    public virtual void Move()
    {
        List<PointField> pointsTemp = new List<PointField>();

        List<PointField> checkPlayerPoints = _field.GetPointsNeighbours(_curPoint);
        foreach (var p in checkPlayerPoints)
        {
            if(p._State == FieldPointState.player) Debug.Log("Player");
        }
        
        pointsTemp = _field.GetPointsNeighboursNoObctacle(_curPoint);
        
        pointsTemp.Remove(_prevPoint);

        Debug.Log(pointsTemp.Count);
        _prevPoint = _curPoint;
        _curPoint = pointsTemp[Random.Range(0, pointsTemp.Count)];
        transform.position = _curPoint.transform.position;
        
    }
}
