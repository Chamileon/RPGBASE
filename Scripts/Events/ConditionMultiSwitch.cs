using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionMultiSwitch: GameEventCondition
{
    [SerializeField] private int[] globalBoolID;
    public virtual int[] ID { get 
        {
            var items = new int[globalBoolID.Length];
            for (int i = 0; i < items.Length; i++) 
            {
                items[i] = globalBoolID[i];
            }
            return items;
        } }
    public override bool IsActive()
    {
        if(CONDITION != null) 
        {
            var flag = true;
            foreach (var item in CONDITION)
            {
                if (!item.IsActive()) flag = false;
            }
            return flag;
        }
        DebugNullCondition();
        return false;


    }
    public new GlobalBool[] CONDITION { get 
        {
            GlobalBool[] bools = new GlobalBool[globalBoolID.Length];
            if(CONDITION != null)
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    bools[i] = God.god.GlobalBools.booleans[globalBoolID[i]];
                }
                return bools;
            }
            DebugNullCondition();
            return null;
        } }
    public override void Activate()
    {
        if (CONDITION != null)
        {
            foreach (GlobalBool item in CONDITION)
            {
                item.Activate();
            }
        }
    }
    public override void Deactivate()
    {
        if (CONDITION != null)
        {
            foreach (GlobalBool item in CONDITION)
            {
                item.Deactivate();
            }
        }
    }
    private void DebugNullCondition() 
    {
        Debug.Log("CONDITION in: " + typeof(ConditionMultiSwitch) + " is null.");

    }
}
