using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private float _timer;
    [SerializeField] private float _onScreenDuration;
    private void Start()
    {
        _timer = 0f;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _onScreenDuration) { this.gameObject.SetActive(false); }
    }
}
