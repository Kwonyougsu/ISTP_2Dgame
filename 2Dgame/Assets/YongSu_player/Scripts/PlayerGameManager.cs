using UnityEngine;

public class PlayerGameManager : MonoBehaviour
{
    public static PlayerGameManager Instance;

    public int PlayerId;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacterId(int id)
    {
        PlayerId = id;
    }
}
