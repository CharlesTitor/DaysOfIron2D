using UnityEngine;

public interface IDamageable
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    bool IsDead { get; set; }

    void TakeDamage(float damage);

}
