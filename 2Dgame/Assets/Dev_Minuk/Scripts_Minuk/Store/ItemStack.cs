using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ItemStack : MonoBehaviour
{
    public ItemData itemData;
    public int index;

    public GameObject[] stack;

    private void Start()
    {
        SetStack();
    }

    public void SetStack()
    {
        if (itemData.itemstack[index] >= 3)
        {
            itemData.itemstack[index] = 3;
            stack[0].SetActive(true);
            stack[1].SetActive(true);
            stack[2].SetActive(true);
        }
        else if (itemData.itemstack[index] >= 2)
        {
            itemData.itemstack[index] = 2;
            stack[0].SetActive(true);
            stack[1].SetActive(true);
        }
        else if (itemData.itemstack[index] >= 1)
        {
            itemData.itemstack[index] = 1;
            stack[0].SetActive(true);
        }
    }
}
