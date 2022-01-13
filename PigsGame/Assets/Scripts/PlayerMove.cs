using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int _startPosX, _startPosY;
    [SerializeField] private Field _field;

    [SerializeField] private Bomb _bomb;
    
    [SerializeField] private Sprite _spriteUp;
    [SerializeField] private Sprite _spriteDown;
    [SerializeField] private Sprite _spriteLeft;
    [SerializeField] private Sprite _spriteRight;


    private int _d;
    private SpriteRenderer _renderer;

    private int _curPosX, _curPosY;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        transform.position = _field.GetMatrixPoint(_startPosX, _startPosY).transform.position;
        _curPosX = _startPosX;
        _curPosY = _startPosY;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || _d == 3) Move(1,0);
        if (Input.GetKeyDown(KeyCode.A) || _d == 4) Move(-1,0);
        if (Input.GetKeyDown(KeyCode.W) || _d == 1) Move(0,1);
        if (Input.GetKeyDown(KeyCode.S) || _d == 2) Move(0, -1);
    }

    public void Move(int dirX, int dirY)
    {
        _d = 0;
        PointField prevPoint = _field.GetMatrixPoint(_curPosX, _curPosY );
        prevPoint._State = FieldPointState.empty;
        
        PointField point = _field.GetMatrixPoint(_curPosX + dirX, _curPosY + dirY);
        
        if (point != null && point._State == FieldPointState.empty)
        {
            point._State = FieldPointState.player;
            GameInfo.init._Step++;
            
            if (dirX == -1)  _renderer.sprite = _spriteLeft;
            if (dirX == 1) _renderer.sprite = _spriteRight;
            if (dirY == -1) _renderer.sprite = _spriteDown;
            if (dirY == 1) _renderer.sprite = _spriteUp;
            
            transform.position = point.transform.position;
            _curPosX += dirX;
            _curPosY += dirY;
        }
    }

    public void Dir(int dir)
    {
        _d = dir;
    }

}
