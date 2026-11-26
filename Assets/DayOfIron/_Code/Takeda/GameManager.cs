using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private string _battleSceneName;
    [SerializeField] private GameObject _mainUI;

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void EnterPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }


    public void ExitPauseMenu()
    {
        _pauseMenu.SetActive(false);
    }

    public void EnterBattle()
    {
        _mainUI.SetActive(false);
        SceneManager.LoadSceneAsync(_battleSceneName,LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == _battleSceneName)
        {
            _mainUI.SetActive(true);
        }
    }
}
