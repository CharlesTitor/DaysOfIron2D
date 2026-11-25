using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private string _battleSceneName;

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
        SceneManager.LoadSceneAsync(_battleSceneName,LoadSceneMode.Additive);
    }
}
