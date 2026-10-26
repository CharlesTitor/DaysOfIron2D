using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private EventChannelSO _interruptMoveChannel;
    [SerializeField] private InputAction _moveClick;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _moveIndicator;

    private Camera _camera;
    private Coroutine _coroutine;
    private Vector3 _targetUbication;
    private Vector3 _destination;
    private Vector2 _mousePosition;
    private bool _isColliding;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _moveClick.Enable();
        _moveClick.performed += Move;
        _interruptMoveChannel.EventChannel.AddListener(InterruptMovement);
    }

    private void OnDisable()
    {
        _moveClick.performed -= Move;
        _moveClick.Disable();
        _interruptMoveChannel.EventChannel.RemoveListener(InterruptMovement);
    }

    private void Move(InputAction.CallbackContext context)
    {
       //
        _mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint( new Vector3(_mousePosition.x, _mousePosition.y, 0f));
        mouseWorldPosition.z = transform.position.z;
        //
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _moveIndicator.SetActive(true);
        _moveIndicator.transform.position = mouseWorldPosition;
        _coroutine = StartCoroutine(PlayerMoveTowards(mouseWorldPosition));
        _targetUbication = mouseWorldPosition;
    }

    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        while (Vector3.Distance(transform.position,target)>0.1f)
        {
            _destination =Vector3.MoveTowards(transform.position,target,_speed*Time.deltaTime);
            transform.position=_destination;
            yield return null;
        }
        _moveIndicator.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_targetUbication, 0.2f);
    }

    private void InterruptMovement()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}