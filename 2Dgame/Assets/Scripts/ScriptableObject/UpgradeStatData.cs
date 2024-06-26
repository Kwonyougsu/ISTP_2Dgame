using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeStat", menuName = "New UpgradeStat")]
public class UpgradeStatData : ScriptableObject
{
    [Header("Info")]
    public Sprite[] statIcon;
    public float[] statLv;
    public string[] statName;
    public string[] statDescription;
}
