using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : MonoBehaviour
{
    public ItemSlot[] slot;
    public Transform slots;

    private void Awake()
    {
        slots = this.transform;
        slot = new ItemSlot[slots.childCount];
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = slots.GetChild(i).GetComponent<ItemSlot>();
            slot[i].index = i;
            slot[i].GetComponent<ItemStack>().index = i;
        }
    }

}
