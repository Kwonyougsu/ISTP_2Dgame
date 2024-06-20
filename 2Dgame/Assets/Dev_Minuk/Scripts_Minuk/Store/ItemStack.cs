using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ItemStack : MonoBehaviour
{
    public ItemData itemData;
    public int index;
    public Transform slot;

    public GameObject[] stack;

    private void Start()
    {
        StartCoroutine("GetStackCilde");
    }
    IEnumerator GetStackCilde()
    {
        yield return null;
        stack = new GameObject[slot.childCount - 4];
        for (int i = 4; i < slot.childCount; i++)
        {
            stack[i - 4] = slot.GetChild(i).gameObject;
        }
        StartCoroutine("SetStacks");
    }

    IEnumerator SetStacks()
    {
        yield return null;
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
            stack[2].SetActive(false);
        }
        else if (itemData.itemstack[index] >= 1)
        {
            itemData.itemstack[index] = 1;
            stack[0].SetActive(true);
            stack[1].SetActive(false);
            stack[2].SetActive(false);
        }
        else if (itemData.itemstack[index] == 0)
        {
            stack[0].SetActive(false);
            stack[1].SetActive(false);
            stack[2].SetActive(false);
        }
    }
}
