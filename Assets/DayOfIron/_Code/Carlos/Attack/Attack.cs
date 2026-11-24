using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    private IDamageable _target;
    public AttackData _attackData;

    public void AttackAction()
    {;

        if( _target == null )
        {
            return;
        }

        //_target.TakeDamage(_damage);
        
        int randomNumber = 0;

        if (_attackData.damageType==DamageType.Impact)
        {
            randomNumber= Random.Range(1, 3);
        }
        else if (_attackData.damageType==DamageType.Blunt)
        {
            randomNumber= Random.Range(1, 4);
        }
        else if (_attackData.damageType==DamageType.Crushing)
        {
            randomNumber= Random.Range(1, 5);
        }

        if (randomNumber==1)
        {
            Debug.Log("Attack successful!");

            _target.TakeDamage(_attackData.fixedDamage);
        }
        else
        {
            Debug.Log("Attack missed!");
        }
    }

    public void setAttackDamage(float damageValue)=>_damage = damageValue;
    public void setAttackTarget(IDamageable validTarget) => _target = validTarget;
}
