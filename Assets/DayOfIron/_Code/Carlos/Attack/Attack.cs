using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    private IDamageable _target;

    public void AttackAction()
    {;

        if( _target == null )
        {
            return;
        }
        
        int randomNumber = 0;

        _target.TakeDamage(_damage);
        if (attackData.damageType==DamageType.Impact)
        {
            randomNumber= Random.Range(1, 3);
        }
        else if (attackData.damageType==DamageType.Blunt)
        {
            randomNumber= Random.Range(1, 4);
        }
        else if (attackData.damageType==DamageType.Crushing)
        {
            randomNumber= Random.Range(1, 5);
        }

        if (randomNumber==1)
        {
            Debug.Log("Attack successful!");

            _target.TakeDamage(attackData.fixedDamage);
        }
        else
        {
            Debug.Log("Attack missed!");
        }
    }

}
