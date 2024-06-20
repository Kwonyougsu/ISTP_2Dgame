using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    public static UIStore instance;

    public ItemData itemData;
    public ItemSlot Itemindex;

    [Header("Select Item")]
    public TextMeshProUGUI itemName;
    public GameObject itemIcon;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPrice;
    public GameObject itemInfo;
    public int curIndex;


    [Header("Item Stack")]
    public GameObject[] itemStack;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Itemindex = GetComponent<ItemSlot>();
        ClearStore();
    }

    void ClearStore()
    {
        itemInfo.SetActive(false);
    }

    public void SetStore()
    {
        for(int i = 0; i < itemStack.Length; i++)
        {
            itemStack[i].TryGetComponent<ItemStack>(out ItemStack stack);
            stack.SetStack();
        }
    }


}
