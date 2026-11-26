using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private int _rNGsus;
    [SerializeField] private int _possibleAttacksQuantity;
    private Attack _enemyAttack;
    private Health _enemyHealth;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private Sprite _dotExe;
    private UnityEngine.UI.Image _image;

    private void Start()
    {
        if (!_enemyAttack){ _enemyAttack = GetComponent<Attack>(); }
        if (!_enemyHealth){ _enemyHealth = GetComponent<Health>(); }
        if (_image==null) { _image = GetComponent<UnityEngine.UI.Image>(); }
    }

    private void Update()
    {
        if (_turnManager.IsEnemyTurn()) {
            if (_enemyHealth.CurrentHealth <= _enemyHealth.MaxHealth/2)
            {
                _image.sprite = _dotExe;
            }
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
