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
    [SerializeField] private Health _player;
    [SerializeField] private Health _enemy;

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
        if (_player.CurrentHealth<=0||_enemy.CurrentHealth<=0) { EndBattle(); }
        if (_battleEnded)
        {
            if(_enemy.CurrentHealth<=0){ InventoryManager.Instance.AddItem(iron, 1); }
            SceneManager.UnloadSceneAsync(gameObject.scene);
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