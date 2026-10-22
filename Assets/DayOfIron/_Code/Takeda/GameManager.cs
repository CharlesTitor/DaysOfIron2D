using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

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
}
