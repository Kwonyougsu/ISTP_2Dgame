using UnityEngine;

public class EnemyDestroyOnDeath : MonoBehaviour
{
    private EnemyHealthSystem healthSystem;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        healthSystem = GetComponent<EnemyHealthSystem>();
        rigidbody = GetComponent<Rigidbody2D>();        
        healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {       
        rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        
    }
}
