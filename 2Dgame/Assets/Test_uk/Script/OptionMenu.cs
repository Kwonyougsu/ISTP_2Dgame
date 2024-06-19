using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
