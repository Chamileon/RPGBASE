using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ConditionSelfSwitch: GameEventCondition
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _selfSwitch;
    public override string NAME => _name;
    public override string DESCRIPTION => _description;
    public override GameEventCondition gameEventCondition => this as ConditionSelfSwitch;
    public new bool CONDITION => _selfSwitch;
    public override bool IsActive()
    {
        return _selfSwitch;
    }
    public override void Activate()
    {
        _selfSwitch  = true;
    }
    public override void Deactivate()
    {
        _selfSwitch = false;
    }
}

