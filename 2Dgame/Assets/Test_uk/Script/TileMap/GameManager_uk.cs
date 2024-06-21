using UnityEngine;

public class GameManager_uk : MonoBehaviour
{
    public static GameManager_uk instance;
    public TopDownMovement player;
    //public Player player;

    private void Awake()
    {
        instance = this;
    }
}
