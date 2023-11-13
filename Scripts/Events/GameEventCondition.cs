using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameEventCondition : IActivate, IBasicInfo
{
    public virtual bool IsActive() => false;

    public virtual GameEventCondition gameEventCondition { get => this; }
    public virtual bool CONDITION { get; }
    public virtual string NAME => this.ToString() + ".name";

    public virtual string DESCRIPTION => "IT's a general description.";

    public virtual void Activate()
    {
        
    }

    public virtual void Deactivate()
    {
        
    }
    public virtual bool IsEqual(EventCondition conditionEnum, GameEventCondition condition) 
    {
        var greenFlag = false;
        
        switch (conditionEnum) 
        {
            case global::EventCondition.None: if (condition == null) greenFlag = true; else greenFlag = false;
                break;
            case global::EventCondition.SingleSwitch:
                var item = new ConditionSimpleSwitch();
                if (condition.GetType() != item.GetType()) greenFlag = true;
                else greenFlag = false;
                break;
            case global::EventCondition.MultiSwitch:
                var item1 = new ConditionMultiSwitch();
                if (condition.GetType() != item1.GetType()) greenFlag = true;
                else greenFlag = false;
                break;
            case global::EventCondition.VariableSwitch:
                var item2 = new ConditionSimpleSwitch();
                if (condition.GetType() != item2.GetType()) greenFlag = true;
                else greenFlag = false;
                break;
            case global::EventCondition.SelfSwitch:
                var item3 = new ConditionSimpleSwitch();
                if (condition.GetType() != item3.GetType()) greenFlag = true;
                else greenFlag = false;
                break;
        }
        return greenFlag;
    }

}
