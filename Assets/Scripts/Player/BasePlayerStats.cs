using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
[Serializable]

public class BasePlayerStats
{
    public string className;
    public float strenght;
    public float dextrity;
    public Sprite symbol;
    public string description;
    public BasePlayerStats()
    {
        className = "newClass";
    }
}