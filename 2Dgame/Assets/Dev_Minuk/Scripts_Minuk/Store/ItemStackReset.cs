using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStackReset : MonoBehaviour
{
    public ItemData itemData;

    private void Awake()
    {
        itemData = GameManager.Instance.itemData;
    }
    public void OnResetStacks()
    {
        for(int i = 0; i < itemData.itemstack.Length; i++)
        {
            GameManager.Instance.playerGold += (itemData.itemstack[i] * itemData.itemprice[i]);
            itemData.itemstack[i] = 0;
        }
        UIStore.instance.SetStore();
        UIStore.instance.ClearStore();
        UIStore.instance.curIndex = null;
    }
}
