using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxItem", menuName = "New BoxItem")]
public class BoxItemData : ScriptableObject
{
        [Header("Info")]
        public Sprite itemIcon;
        public string itemName;
        public string itemDescription;
        public int itemstack;
}
