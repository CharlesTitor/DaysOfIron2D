using UnityEngine;
using UnityEngine.SceneManagement;

public class HoldUp : MonoBehaviour
{
    [SerializeField] private ItemData _ironData;
    [SerializeField] private string _battleSceneName;
    private bool _selected;

    [SerializeField] private int _letGoReward=1;
    [SerializeField] private int _stealReward=2;
    [SerializeField] private int _killReward=3;

    public void LetHimGo()
    {
        GiveReward(_letGoReward);
    }

    public void Steal()
    {
        GiveReward(_stealReward);
    }

    public void KillHim()
    {
        GiveReward(_killReward);
    }

    private void GiveReward(int quantity)
    {
        if (_selected)
        {
            return;
        }

        _selected = true;

        InventoryManager.Instance.AddItem(_ironData, quantity);
        //Cierra ambas escenas sobrepuestas
        SceneManager.UnloadSceneAsync(gameObject.scene);
        SceneManager.UnloadSceneAsync(_battleSceneName);
    }
}
