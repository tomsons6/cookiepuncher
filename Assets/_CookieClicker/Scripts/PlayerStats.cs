using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float cookieCount = 0;
    public float punchStrenght = 1;
    public int currentBagLevelTotal = 10;
    public int bagHitsLeft = 10;
    public bool IntroSequence = false;

}
