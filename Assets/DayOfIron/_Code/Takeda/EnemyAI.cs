using NaughtyAttributes;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private int _rNGsus;
    [SerializeField] private int _possibleAttacksQuantity;
    private Attack _basicAttack;
    private Attack _mediumAttack;
    private Attack _heavyAttack;

    private Attack _randomizedAttack;

    void Start()
    {
        _basicAttack.setAttackDamage(10);
        //_basicAttack.setAttackTarget(Player);
        _mediumAttack.setAttackDamage(20);
        //_basicAttack.setAttackTarget(Player);
        _heavyAttack.setAttackDamage(40);
        //_basicAttack.setAttackTarget(Player);
        _randomizedAttack.setAttackDamage(Random.Range(0, 101));
        //_basicAttack.setAttackTarget(Player);
    }

    private void AttackSelection()
    {
        _rNGsus = Random.Range(1,_possibleAttacksQuantity+1);
        switch (_rNGsus)
        {
            case 1:
                _basicAttack.AttackAction();
                break;
            case 2:
                _mediumAttack.AttackAction();
                break;
            case 3:
                _heavyAttack.AttackAction();
                break;
            default:
                Debug.Log("They execute a RANDOMIZED attack!");
                _randomizedAttack.AttackAction();
                break;
        }
    }
}
