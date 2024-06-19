using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : MonoBehaviour
{
    public ItemData[] itemData;
    public GameObject[] slots;

    Transform targetParent;
    void Start()
    {
        for(int i = 0; i < itemData.Length; i++)
        {
            slots[i].gameObject.SetActive(true);
        }
    }

}
