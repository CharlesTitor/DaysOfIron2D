using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    [SerializeField] private Health _target;
    public AttackData _attackData;
    [SerializeField] private TurnManager _turnManager;

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
        _turnManager.EndTurn();
    }

    public void setAttackDamage(int damageValue)=>_attackData.fixedDamage = damageValue;
    public void setAttackTarget(Health validTarget) => _target = validTarget;
}
