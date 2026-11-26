using UnityEngine;

public class Attack : MonoBehaviour
{
    //[SerializeField] private float _damage = 20f;
    [SerializeField] private Health _target;
    public AttackData _attackData;
    [SerializeField] private TurnManager _turnManager;

    public void AttackAction()
    {

        if( _target == null )
        {
            Debug.Log("Target not found");
            return;
        }

        //_target.TakeDamage(_damage);
        
        int randomNumber = Random.Range(1, 101);

        if (_attackData.damageType == DamageType.Impact)
        {
            if (randomNumber <= 90)
            {
                _target.TakeDamage(_attackData.fixedDamage);
                Debug.Log("Attack successful!");
            }
            else
            {
                Debug.Log("Attack missed!");
            }
        }
        else if (_attackData.damageType == DamageType.Blunt)
        {
            if (randomNumber <= 61)
            {
                _target.TakeDamage(_attackData.fixedDamage);
                Debug.Log("Attack successful!");
            }
            else
            {
                Debug.Log("Attack missed!");
            }
        }
        else if (_attackData.damageType == DamageType.Crushing)
        {
            if (randomNumber <= 31)
            {
                _target.TakeDamage(_attackData.fixedDamage);
                Debug.Log("Attack successful!");
            }
            else
            {
                Debug.Log("Attack missed!");
            }
        }

        _turnManager.EndTurn();
    }

    public void setAttackDamage(int damageValue)=>_attackData.fixedDamage = damageValue;
    public void setAttackTarget(Health validTarget) => _target = validTarget;
}
