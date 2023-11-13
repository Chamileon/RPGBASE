using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicInfo 
{
    public string NAME { get; }
    
    public string DESCRIPTION { get; }
}
public interface IActivate 
{
    public bool IsActive();
    public void Activate();
    public void Deactivate();
}
public interface IGameEventCondition 
{
    public IGameEventCondition gameEventCondition { get; }
}

