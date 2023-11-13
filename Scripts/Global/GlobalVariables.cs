using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a GlobalVariables", fileName = "New GlobalVariable")]
public class GlobalVariables : ScriptableObject
{
    public GlobalInt[] variables;
}
[System.Serializable]
public class GlobalInt : IBasicInfo, IActivate
{
    [SerializeField] private string _name;
    [SerializeField] [TextArea(1, 20)] private string _description;
    public string NAME => _name;

    public string DESCRIPTION => _description;

    public bool IsActive() 
    {
        var flag = false;
        if (_variable >= _activeInt) flag = true;
        return flag;
    }

    [SerializeField] private int _variable;
    [SerializeField] private int _activeInt;

    public void Activate()
    {
        _variable = _activeInt;
    }

    public void Deactivate()
    {
        _variable = 0;
    }
}
