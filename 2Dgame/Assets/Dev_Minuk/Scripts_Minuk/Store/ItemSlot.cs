using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [Header("Need Connection")]
    public ItemData itemData;

    [Header("Slot")]
    public int index;
    public GameObject itemIcon;
    public ItemStack itemStack;

    public Transform slot;
    private void Start()
    {
        slot = this.transform;
        itemIcon = slot.GetChild(0).gameObject;
        itemStack = GetComponent<ItemStack>();
        itemStack.itemData = itemData;
        itemStack.slot = slot;
        StartCoroutine("GetSprite");
    }

    IEnumerator GetSprite()
    {
        yield return null;
        itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
    }
    /*
    private void GetSprites()
    {
        itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
    }
    */
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
        UIStore.instance.itemPrice.text = $"{itemData.itemprice[index]} G";
    }
}
