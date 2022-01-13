using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Finish : MonoBehaviour
{
    public event UnityAction FinishAction;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            if (GameObject.FindObjectsOfType<Apple>().Length <= 0)
            {
                FinishAction?.Invoke();
            }
        }
    }
    
    
}
