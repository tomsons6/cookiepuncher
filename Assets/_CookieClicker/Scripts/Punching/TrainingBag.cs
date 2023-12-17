using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainingBag : Punchable
{
    [SerializeField]
    TMP_Text remainingHits;
    public override void Start()
    {
        base.Start();
        ChangeText();
    }
    public override void punched()
    {
        if (GameManager.Instance.playerStats.bagHitsLeft == 1)
        {
            LevelUp();
        }
        else
        {
            GameManager.Instance.playerStats.bagHitsLeft--;
            ChangeText();
        }
        base.punched();
    }
    void LevelUp()
    {
        int levelUpValue = GameManager.Instance.playerStats.currentBagLevelTotal + 5;
        PlayerStats stats = GameManager.Instance.playerStats;
        stats.currentBagLevelTotal = levelUpValue;
        stats.bagHitsLeft = levelUpValue;
        stats.punchStrenght += .2f;
        ChangeText();
    }
    void ChangeText()
    {
        remainingHits.text = GameManager.Instance.playerStats.bagHitsLeft.ToString();
    }
}
