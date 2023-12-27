using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeJar", menuName = "ScriptableObjects/UpgradeJar", order = 2)]
public class UpgradeJarScriptable : ScriptableObject
{
    public int price;
    public string upgradeDescription;
    public bool upgradeBought = false;
}
