using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a GlobalBools", fileName = "New GlobalBool")]
public class GlobalBools : ScriptableObject
{
    public GlobalBool[] booleans;
}
[System.Serializable]
public class GlobalBool : IBasicInfo, IActivate
{
    [SerializeField] private string _name;
    [SerializeField][TextArea(1,20)] private string _description;
    public string NAME => _name;

    public string DESCRIPTION => _description;

    public bool IsActive() => _active;

    [SerializeField] private bool _active = false;

    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
}