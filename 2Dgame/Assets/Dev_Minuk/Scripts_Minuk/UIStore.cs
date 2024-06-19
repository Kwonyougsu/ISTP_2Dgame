using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStore : MonoBehaviour
{
    public ItemSlot[] slots;

    public GameObject StoreUI;
    public Transform slotPanel;

    [Header("Select Item")]
    public TextMeshProUGUI itemName;
    public GameObject itemIcon;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPrice;
    public GameObject buyButton;

    void Start()
    {
        slots = new ItemSlot[slotPanel.childCount];
        ClearStore();
    }

    void ClearStore()
    {
        itemName.text = string.Empty;
        itemDescription.text = string.Empty;
        itemPrice.text = string.Empty;

        itemIcon.SetActive(false);
        buyButton.SetActive(false);
    }
}
