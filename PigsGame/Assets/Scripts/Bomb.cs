using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : ItemField
{
    [SerializeField] private int _timeActivation;
    [SerializeField] private TMP_Text textTime;
    private int curStep;
    private PointField curPointField;

    void Start()
    {
        curStep = GameInfo.init._Step;
        GameInfo.init.NextStepAction += Time;
    }

    private void OnDisabled()
    {
        //GameInfo.init.NextStepAction -= Time;
    }

    private void Time()
    {
        _timeActivation--;
        textTime.text = _timeActivation.ToString();
        if (_timeActivation <= 0)
        {
            Boom();
        }
    }

    public void Activate(PointField pointField)
    {
        textTime.text = _timeActivation.ToString();
        curPointField = pointField;
        
    }
    private void Boom()
    {
        List<PointField> points = new List<PointField>();
        //curPointField._State = FieldPointState.empty;
        Destroy(gameObject);
    }
}
