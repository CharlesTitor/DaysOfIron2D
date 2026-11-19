using NaughtyAttributes;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private int _rNGsus;
    [SerializeField] private int _possibleAttacksQuantity;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AttackSelection()
    {
        _rNGsus = Random.Range(1,_possibleAttacksQuantity+1);
        switch (_rNGsus)
        {
            case 1:
                //attack 1
                break;
            case 2:
                //attack 2
                break;
            case 3:
                //attack 3
                break;
            default:
                Debug.Log("They execute a RANDOMIZED attack!");
                //damage=Random.Range(0,101);
                break;
        }
    }
}
