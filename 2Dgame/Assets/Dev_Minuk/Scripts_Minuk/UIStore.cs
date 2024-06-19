using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    public ItemData itemData;
    public ItemSlot Itemindex;

    [Header("Select Item")]
    public TextMeshProUGUI itemName;
    public GameObject itemIcon;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPrice;
    public GameObject itemInfo;

    void Start()
    {
        Itemindex = GetComponent<ItemSlot>();
        ClearStore();
    }

    void ClearStore()
    {
        itemInfo.SetActive(false);
    }

    public void OnClickButton()
    {
        SetStoreInfo(Itemindex.index);
    }

    public void SetStoreInfo(int index)
    {
        itemInfo.SetActive(true);
        itemName.text = itemData.itemName[index];
        itemIcon.TryGetComponent<Image>(out Image icon);
        icon.sprite = itemData.itemIcon[index];
        itemDescription.text = itemData.itemDescription[index];
        itemPrice.text = itemData.itemprice[index];
    }
}
