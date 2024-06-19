using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public Sprite[] itemIcon;
    public string[] itemName;
    public string[] itemDescription;
    public string[] itemprice;
}
