using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionVariableSwitch : GameEventCondition, IBasicInfo
{
    [SerializeField] private int _globalVariableID;
    public virtual int ID => _globalVariableID;
    public new GlobalInt CONDITION { get => God.god.GlobalVariables.variables[_globalVariableID]; }
    public override string NAME => CONDITION.NAME;
    public override string DESCRIPTION => CONDITION.DESCRIPTION;
    public override GameEventCondition gameEventCondition => this as ConditionVariableSwitch;
    public override bool IsActive() 
    {
        if(CONDITION != null) return CONDITION.IsActive();
        ConditionNullDebug();
        return false;
    }
    public override void Activate() 
    {
        if (CONDITION != null) 
        { 
            CONDITION.Activate();
            return;
        }
        ConditionNullDebug();

    }
    public override void Deactivate()
    {
        if (CONDITION != null)
        {
            CONDITION.Deactivate();
            return;
        }
        ConditionNullDebug();
    }
    private void ConditionNullDebug() 
    {
        Debug.Log("CONDITION in: " + typeof(ConditionVariableSwitch) + " is null");
    }
}
