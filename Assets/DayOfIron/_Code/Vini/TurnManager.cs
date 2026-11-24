using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    private enum TurnState
    {
        Player,
        Enemy,
        Finished
    }

    private TurnState _currentTurn;
    private bool _battleEnded;
    [SerializeField] private ItemData iron;

    void Start()
    {
    StartBattle();
    }

    public void StartBattle()
    {
     _currentTurn = TurnState.Player;
     _battleEnded = false;

    Debug.Log("Player Turn");
    }

    public void EndTurn()
    {
        if (_battleEnded) {
            InventoryManager.Instance.AddItem(iron,4);
            SceneManager.LoadScene(2);
            return;
        }

        if (_currentTurn == TurnState.Player)

        {
            _currentTurn = TurnState.Enemy;
            Debug.Log("Enemy Turn");
        }

        else if (_currentTurn == TurnState.Enemy)

        {
            _currentTurn = TurnState.Player;
            Debug.Log("Player Turn");
        }
    }

    public void EndBattle()
    {
     _battleEnded = true;
     _currentTurn = TurnState.Finished;

        Debug.Log("Battle Finished");
    }

    public bool IsPlayerTurn()
    {
        return _currentTurn == TurnState.Player;
    }

    public bool IsEnemyTurn()
    {
        return _currentTurn == TurnState.Enemy;
    }
}