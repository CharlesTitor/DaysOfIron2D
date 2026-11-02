using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
