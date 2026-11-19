using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;
    private bool _isDead = false;

    void Awake()
    {
        _currentHealth = _maxHealth;
    }


    public void TakeDamage(float damage)
    {
        if (_isDead)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth < 0f)
        {
            _currentHealth = 0f;
        }
        Debug.Log(gameObject.name + " received " + damage + " damage. Current health: " + _currentHealth);

        if (_currentHealth <= 0f)
        {
            IsDead();
        }
    }

    public void IsDead()
    {
        _isDead = true;
        Destroy(gameObject);
    }
    
}
