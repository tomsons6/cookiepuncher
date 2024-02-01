using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAutoFists : UpgradeJar
{
    HandModelSelector modelSelector;
    public override void BoughtUpgrade()
    {
        base.BoughtUpgrade();
        int i = 0;
        foreach(Punchable punch in FindObjectsOfType<Punchable>())
        {
            punch.autoFist = true;
        }
        modelSelector = FindObjectOfType<HandModelSelector>();
        modelSelector.ChangeHandsModel(0);
    }
}
