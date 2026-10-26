
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour, IInteractor
{
    [Header("References")]
    [SerializeField] private EventChannelSO _interruptMoveChannel;
    [SerializeField] private GameObject _moveIndicator;

    [Header("Input")]
    [SerializeField] private InputAction _moveClick;
    [SerializeField] private InputAction _interactClick;

    [Header("Movement")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private LayerMask _groundLayer;

    private Camera _camera;
    private Coroutine _coroutine;
    private Vector3 _targetUbication;
    private Vector3 _destination;
    private Vector2 _mousePosition;
    private Vector3 _mouseWorldPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _moveClick.Enable();
        _interactClick.Enable();

        _moveClick.performed += Move;
        _interactClick.performed += ClickInteract;

        _interruptMoveChannel.EventChannel.AddListener(InterruptMovement);
    }

    private void OnDisable()
    {
        _moveClick.performed -= Move;
        _interactClick.performed -= ClickInteract;

        _moveClick.Disable();
        _interactClick.Disable();

        _interruptMoveChannel.EventChannel.RemoveListener(InterruptMovement);
    }

    private Vector3 GetMouseWorldPosition()
    {
        _mousePosition = Mouse.current.position.ReadValue();

        float distanceFromCamera =
            Mathf.Abs(_camera.transform.position.z - transform.position.z);

        _mouseWorldPosition = _camera.ScreenToWorldPoint(
            new Vector3(
                _mousePosition.x,
                _mousePosition.y,
                distanceFromCamera
            )
        );

        _mouseWorldPosition.z = transform.position.z;

        return _mouseWorldPosition;
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _moveIndicator.SetActive(true);
        _moveIndicator.transform.position = mouseWorldPosition;

        _targetUbication = mouseWorldPosition;
        _coroutine = StartCoroutine(
            PlayerMoveTowards(mouseWorldPosition)
        );
    }

    private void ClickInteract(InputAction.CallbackContext context)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();

        Collider2D hitCollider = Physics2D.OverlapPoint(
            new Vector2(mouseWorldPosition.x, mouseWorldPosition.y)
        );

        if (hitCollider == null)
        {
            return;
        }

        IInteractable currentInteractable =
            hitCollider.GetComponentInChildren<IInteractable>();

        if (currentInteractable == null)
        {
            currentInteractable =
                hitCollider.GetComponentInParent<IInteractable>();
        }

        if (currentInteractable != null)
        {
            if (currentInteractable.CanInteract(this))
            {
                currentInteractable.Interact(this);
            }
        }
    }

    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            _destination = Vector3.MoveTowards(
                transform.position,
                target,
                _speed * Time.deltaTime
            );

            transform.position = _destination;

            yield return null;
        }

        _moveIndicator.SetActive(false);
        _coroutine = null;
    }

    private void InterruptMovement()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        if (_moveIndicator != null)
        {
            _moveIndicator.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_targetUbication, 0.2f);
    }
}