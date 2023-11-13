using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventPage
{
    [Header("Aparience")]
    public Sprite sprite;
    [Header("Conditions")]
    public EventCondition switchCondition = EventCondition.None;
    public ConditionSimpleSwitch singleSwitch;
    public ConditionMultiSwitch multiSwitch;
    public ConditionVariableSwitch variableSwitch;
    public ConditionSelfSwitch selfSwitch; 
    public GameEventCondition Condition() 
    {
        switch (this.switchCondition) 
        {
            case EventCondition.SingleSwitch:
                return singleSwitch;
            case EventCondition.MultiSwitch:
                return multiSwitch;
            case EventCondition.VariableSwitch:
                return variableSwitch;
            case EventCondition.SelfSwitch:
                return selfSwitch;
                default: return null;
                
        }
        
    }
    [Header("Move Options")]
    public EventMoveType moveType;
    [Range(1f,20f)] public float moveSpeed;
    [Range(0.1f, 0.9f)] public float moveNoiseScale;
    public Vector2 noiseOffset;
    
}
