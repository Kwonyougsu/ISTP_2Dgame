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
    private void Start()
    {
        GetSprite();
    }

    private void GetSprite()
    {
        itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
    }
    public void OnClickButton()
    {
        SetStoreInfo(index);
    }

    public void SetStoreInfo(int index)
    {
        UIStore.instance.curIndex = index;
        UIStore.instance.itemInfo.SetActive(true);
        UIStore.instance.itemName.text = itemData.itemName[index];
        UIStore.instance.itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
        UIStore.instance.itemDescription.text = itemData.itemDescription[index];
        UIStore.instance.itemPrice.text = $"{itemData.itemprice[index]}";
    }
}
