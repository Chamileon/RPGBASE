using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public static God god;
    private void Awake()
    {
        if (god == null) god = this;
        else Destroy(gameObject);
    }
    public GlobalBools GlobalBools;
    public GlobalVariables GlobalVariables;
}
