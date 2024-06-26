using UnityEngine;

public class EnemyDestroyOnDeath : MonoBehaviour
{
    private EnemyHealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _healthSystem = GetComponent<EnemyHealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();        
        _healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {       
        _rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);        
    }
}
