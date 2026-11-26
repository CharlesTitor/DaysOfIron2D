using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    bool IDamageable.IsDead { get => _isDead; set => _isDead = value; }

    private float _maxHealth = 100f;
    private float _currentHealth;
    private bool _isDead = false;

    private Image _image;
    private float _timer=0;
    private float _fadeoutDuration = 0.5f;

    void Awake()
    {
        _currentHealth = _maxHealth;
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_image.color != Color.white)
        {
            _image.color = new Color(
                _image.color.r, 
                Mathf.Min(1,_image.color.g+Time.deltaTime/_fadeoutDuration), 
                Mathf.Min(1,_image.color.b+Time.deltaTime/_fadeoutDuration));
        }
    }

    public void TakeDamage(float damage)
    {
        if (_isDead)
        {
            return;
        }

        _currentHealth -= damage;
        _image.color = Color.red;

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
        //Destroy(gameObject);
    }
    
}
