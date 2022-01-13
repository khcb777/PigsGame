using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameInfo : MonoBehaviour
{
    public static GameInfo init;
    
    public Field _Field;
    public Finish _Finish;
    public CheckPlayer CheckPlayer;
    public event UnityAction NextStepAction;

    public int _Step
    {
        get { return _step; }
        set
        {
            if (value > 0)
            {
                _step++;
                NextStepAction?.Invoke();
            }
        }
    }

    private int _step;

    public void Awake()
    {
        init = this;
    }
}
