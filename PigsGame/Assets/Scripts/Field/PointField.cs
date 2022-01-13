using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointField : MonoBehaviour
{
    public Vector2Int PositionMatrix { get; private set; }
    
    [SerializeField] private Apple _apple;
    [SerializeField] private Bomb _bombPref;
    [SerializeField] private Stone _stonePref;

    private FieldPointState _state;
    private ItemField _item;
    

    public FieldPointState _State
    {
        get { return _state; }
        set
        {
            if (value == FieldPointState.empty)
            {
                if(_item != null) Destroy(_item);
            }
            

            if (value == FieldPointState.stone)
            {
                _item = Instantiate(_stonePref, transform.position, Quaternion.identity,transform);
            }

            _state = value;
        }
    }
    

    public PointField Create(Vector2Int positionMatrix, Vector2 padding, float tiltX, Transform parent)
    {
        PositionMatrix = positionMatrix;

        transform.position = new Vector3(positionMatrix.x * padding.x + tiltX,positionMatrix.y * padding.y,0);
        
        transform.parent = parent;
        
        
        return this;
    }

    public void AddApple()
    {
        Instantiate(_apple, transform.position, Quaternion.identity);
    }

    public void UpdateTransform(Vector2 padding, float tiltX)
    {
        transform.position = new Vector3(PositionMatrix.x * padding.x + tiltX,PositionMatrix.y * padding.y,0);
    }

    

}

public enum FieldPointState
{
    empty,
    stone,
    player,
}
