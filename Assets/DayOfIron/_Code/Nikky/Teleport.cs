using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject _portal;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _teleportTime=1;
    private bool _canTeleport=true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _canTeleport)
        {
            _canTeleport=false;
            _player.transform.position= new Vector2(_portal.transform.position.x, _portal.transform.position.y);
            StartCoroutine(Teleporter());
        }
    }

    private IEnumerator Teleporter()
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
