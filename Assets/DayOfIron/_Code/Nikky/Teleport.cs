using System.Collections;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    [SerializeField] private EventChannelSO _interruptMoveChannel;
    [SerializeField] private GameObject _portal;
    [SerializeField] private float _teleportTime=1;
    private bool _canTeleport=true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _canTeleport)
        {
            _canTeleport = false;
            _interruptMoveChannel.EventChannel?.Invoke();
            other.gameObject.transform.position = new Vector2(_portal.transform.position.x, _portal.transform.position.y);
            StartCoroutine(TeleportCooldown());
        }
    }

    private IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(_teleportTime);
        _canTeleport=true;
    }

    /*
    [SerializeField] private Transform _teleportPoint;

    private void OnTriggerEnter(Collider kael)
    {
        if (kael.CompareTag("Player"))
        {
            kael.transform.position = _teleportPoint.position;
        }
    }
    */

}
