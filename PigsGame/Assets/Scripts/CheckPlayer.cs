using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPlayer : MonoBehaviour
{
    public event UnityAction DieAction;
    
    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.TryGetComponent(out Player player))
        {
            DieAction?.Invoke();
        }
    }
}
