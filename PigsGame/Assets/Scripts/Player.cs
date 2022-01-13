using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Apple apple))
        {
            Destroy(apple.gameObject);
        }
    }
}
