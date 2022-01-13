using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Stone _stonePref;
    [Header("Настройки отображения сетки")]
    [SerializeField] private int _matrixSizeX;
    [SerializeField] private int _matrixSizeY;
    [SerializeField] private PointField _pointField;
    [SerializeField] private float _tiltX;
    [SerializeField] private Vector2 _paddingPoints;
    [SerializeField] private int ProbabilityOfAnApple = 10;
    
    private PointField[,] _pointsField;
    

    private void Start()
    {
        Create();
        UpdatePositionMatrix();
    }



    private void Create()
    {
        _pointsField = new PointField[_matrixSizeX,_matrixSizeY];
        float tempTilt = 0;
        for (int y = 0; y < _matrixSizeY; y++)
        {
            tempTilt = _tiltX * y;
            for (int x = 0; x < _matrixSizeX; x++)
            {
                PointField temtPoint = Instantiate(_pointField);
                temtPoint.Create(new Vector2Int(x, y), _paddingPoints,tempTilt ,transform);
                _pointsField[x, y] = temtPoint;
                
                if (y % 2 != 0 && x % 2 != 0) _pointsField[x, y]._State = FieldPointState.stone;
                else
                {
                    _pointsField[x, y]._State = FieldPointState.empty;

                    int r = Random.Range(0, ProbabilityOfAnApple);
                    if (r == 0)
                    {
                        _pointsField[x, y].AddApple();
                    }
                }
                
            }
        }
        
    }
    

    private void UpdatePositionMatrix()
    {
        float tempTilt = 0;
        for (int y = 0; y < _matrixSizeY; y++)
        {
            tempTilt = _tiltX * y;
            for (int x = 0; x < _matrixSizeX; x++)
            {
                _pointsField[x, y].UpdateTransform(_paddingPoints,tempTilt );
            }

            
        }
    }

    public PointField GetMatrixPoint(int x, int y)
    {
        if (x >= 0 && x < _matrixSizeX)
        {
            if (y >= 0 && y < _matrixSizeY)
            {
                return _pointsField[x, y];
            }
        }

        return null;
    }

    public List<PointField> GetPointsNeighbours(PointField pointField)
    {
        List<PointField> points = new List<PointField>();
        int x = pointField.PositionMatrix.x;
        int y = pointField.PositionMatrix.y;
        
        if(GetMatrixPoint(x-1,y) != null) points.Add(GetMatrixPoint(x-1,y));
        if(GetMatrixPoint(x+1,y) != null) points.Add(GetMatrixPoint(x+1,y));
        if(GetMatrixPoint(x,y-1) != null) points.Add(GetMatrixPoint(x,y-1));
        if(GetMatrixPoint(x,y+1) != null) points.Add(GetMatrixPoint(x,y+1));

        return points;
    }

    public List<PointField> GetPointsNeighboursNoObctacle(PointField pointField)
    {
        List<PointField> points = new List<PointField>();

        foreach (var p in GetPointsNeighbours(pointField))
        {
            if(p._State == FieldPointState.empty) points.Add(p);
            
        }

        return points;
    }

}


