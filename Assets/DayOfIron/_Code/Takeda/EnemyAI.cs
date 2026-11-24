using NaughtyAttributes;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private int _rNGsus;
    [SerializeField] private int _possibleAttacksQuantity;
    private Attack _enemyAttack;
    [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        if (!_enemyAttack)
        {
            _enemyAttack = GetComponent<Attack>();
        }
    }

    private void Update()
    {
        if (_turnManager.IsEnemyTurn()) {
            AttackSelection();
        }
    }

    private void AttackSelection()
    {
        _rNGsus = Random.Range(1,_possibleAttacksQuantity+1);
        switch (_rNGsus)
        {
            case 1:
                Debug.Log("Enemy Basic Attack");
                _enemyAttack.setAttackDamage(10);
                _enemyAttack._attackData.damageType = DamageType.Impact;
                break;
            case 2:
                Debug.Log("Enemy Blunt Attack");
                _enemyAttack.setAttackDamage(20);
                _enemyAttack._attackData.damageType = DamageType.Blunt;
                break;
            case 3:
                Debug.Log("Enemy Crushing Attack");
                _enemyAttack.setAttackDamage(40);
                _enemyAttack._attackData.damageType = DamageType.Crushing;
                break;
            default:
                Debug.Log("They execute a RANDOMIZED attack!");
                _enemyAttack.setAttackDamage(Random.Range(0, 101));
                _enemyAttack._attackData.damageType = DamageType.Impact;
                break;
        }
        _enemyAttack.AttackAction();
    }
}
