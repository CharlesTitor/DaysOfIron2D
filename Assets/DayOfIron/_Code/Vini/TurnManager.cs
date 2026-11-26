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
    private bool _holdUpSceneOpened;

    [SerializeField] private ItemData iron;
    [SerializeField] private Health _player;
    [SerializeField] private Health _enemy;
    [SerializeField] private GameObject _attacksCanvas;

    [SerializeField] private string _holdUpSceneName;

    void Start()
    {
        StartBattle();
    }

    public void StartBattle()
    {
        _currentTurn = TurnState.Player;
        _battleEnded = false;
        _holdUpSceneOpened=false;

        Debug.Log("Player Turn");
    }

    public void EndTurn()
    {
        
        //jugador pierde
        if (_player.CurrentHealth<=0) 
        {
            EndBattle();  
            SceneManager.UnloadSceneAsync(gameObject.scene);
            return;
        }
        //Abrimos la escena Hold up
        if (_enemy.CurrentHealth<=20 && !_holdUpSceneOpened)
        {
            _holdUpSceneOpened= true;
            EndBattle();
            SceneManager.LoadScene(_holdUpSceneName, LoadSceneMode.Additive);
            return;
        }

        if (_battleEnded)
        {
            return;
        }

        if (_currentTurn == TurnState.Player)
        {
            _currentTurn = TurnState.Enemy;
            _attacksCanvas.SetActive(false);
            Debug.Log("Enemy Turn");
        }
        else if (_currentTurn == TurnState.Enemy)
        {
            _currentTurn = TurnState.Player;
            _attacksCanvas.SetActive(true);
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