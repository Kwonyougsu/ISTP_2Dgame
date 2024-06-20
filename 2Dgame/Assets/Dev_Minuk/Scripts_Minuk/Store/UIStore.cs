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

    [Header("Need Connection")]
    public ItemData itemData;
    public Transform slots;
    public Transform itemInfoPos;


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
        itemStack = new GameObject[slots.childCount];
        for(int i = 0; i < slots.childCount; i++)
        {
            itemStack[i] = slots.GetChild(i).gameObject;
        }
        itemName = itemInfoPos.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemIcon = itemInfoPos.GetChild(2).gameObject;
        itemDescription = itemInfoPos.GetChild(3).GetComponent<TextMeshProUGUI>();
        itemPrice = itemInfoPos.GetChild(4).GetComponent<TextMeshProUGUI>();
        itemInfo = itemInfoPos.gameObject;
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
