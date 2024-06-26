using UnityEngine;

public class StoreMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject storeMenu;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        storeMenu.SetActive(false);
    }
}
