using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ConditionSimpleSwitch :  GameEventCondition,IBasicInfo
{
    [SerializeField] private int _globalBoolID = 0;
    public virtual int ID => _globalBoolID;
    public new GlobalBool CONDITION { get => God.god.GlobalBools.booleans[_globalBoolID]; }
    public override bool IsActive()
    {
        var item = CONDITION.IsActive();
        return item;
    }
    public override void Activate()
    {
        var item = CONDITION;
        if (item != null) item.Activate();
    }
    public override void Deactivate()
    {
        var item = CONDITION;
        if (item != null) item.Deactivate();
    }
    
    public override GameEventCondition gameEventCondition => this as ConditionSimpleSwitch;

    public override string NAME
    {
        get
        {
            if (CONDITION != null) return God.god.GlobalBools.booleans[_globalBoolID].NAME;
            DebugNullCondition();
            return null;
        }
    }
    public override string DESCRIPTION 
    {
        get
        {
            if (CONDITION != null) return God.god.GlobalBools.booleans[_globalBoolID].DESCRIPTION;
            DebugNullCondition();
            return null;
        }
    }
    private void DebugNullCondition() 
    {
        Debug.Log("CONDITION in: " + typeof(ConditionSimpleSwitch) + " is null.");
    }
}
