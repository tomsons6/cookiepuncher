using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoCruncher", menuName = "ScriptableObjects/AutoCruncher", order = 3)]
public class AutoChruncherScriptable : ScriptableObject
{
    public float crunchStrenght;
    public float waitTime;
}
