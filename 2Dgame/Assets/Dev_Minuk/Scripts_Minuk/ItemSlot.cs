using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData itemData;
    public int index;
    public GameObject itemIcon;

    [SerializeField] Sprite sprite;
    private void Start()
    {
        GetSprite();
    }

    private void GetSprite()
    {
        itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
        sprite = itemData.itemIcon[(index)];
    }
}
