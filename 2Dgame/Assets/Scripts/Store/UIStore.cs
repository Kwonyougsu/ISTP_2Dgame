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
    public Transform slots;
    public Transform itemInfoPos;


    [Header("Select Item")]
    public ItemData itemData;
    public TextMeshProUGUI itemName;
    public GameObject itemIcon;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPrice;
    public GameObject itemInfo;
    public int? curIndex;


    [Header("Item Stack")]
    public GameObject[] itemStack;

    [Header("Player Gold")]
    public TextMeshProUGUI playerGoldTxt;
    public Transform storeMenu;
    public Transform playerGold;

    private void Awake()
    {
        curIndex = null;
        instance = this;
        storeMenu = this.transform;
        playerGold = storeMenu.GetChild(5).transform;
        playerGoldTxt = playerGold.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemData = GameManager.Instance.itemData;
        itemStack = new GameObject[slots.childCount];
        for (int i = 0; i < slots.childCount; i++)
        {
            itemStack[i] = slots.GetChild(i).gameObject;
        }
        itemName = itemInfoPos.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemIcon = itemInfoPos.GetChild(2).gameObject;
        itemDescription = itemInfoPos.GetChild(3).GetComponent<TextMeshProUGUI>();
        itemPrice = itemInfoPos.GetChild(4).GetComponent<TextMeshProUGUI>();
        itemInfo = itemInfoPos.gameObject;
    }

    void Start()
    {
        ClearStore();
    }

    public void ClearStore()
    {
        playerGoldTxt.text = $"{GameManager.Instance.playerGold} G";
        itemInfo.SetActive(false);
    }

    public void SetStore()
    {
        playerGoldTxt.text = $"{GameManager.Instance.playerGold} G";
        for (int i = 0; i < itemStack.Length; i++)
        {
            itemStack[i].TryGetComponent<ItemStack>(out ItemStack stack);
            stack.SetStack();
        }
    }


}
