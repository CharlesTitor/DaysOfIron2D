using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private InputAction _moveClick;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _moveIndicator;

    private Camera camera;
    private Coroutine coroutine;
    private Vector3 targetUbication;
    private Vector3 destination;
    private Vector2 mousePosition;
    private bool isColliding;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void OnEnable()
    {
        _moveClick.Enable();
        _moveClick.performed += Move;
    }

    private void OnDisable()
    {
        _moveClick.performed -= Move;
        _moveClick.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
       //
        mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint( new Vector3(mousePosition.x, mousePosition.y, 0f));
        mouseWorldPosition.z = transform.position.z;
        //
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        _moveIndicator.SetActive(true);
        _moveIndicator.transform.position = mouseWorldPosition;
        coroutine = StartCoroutine(PlayerMoveTowards(mouseWorldPosition));
        targetUbication = mouseWorldPosition;
    }

    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        while (Vector3.Distance(transform.position,target)>0.1f)
        {
            destination =Vector3.MoveTowards(transform.position,target,_speed*Time.deltaTime);
            transform.position=destination;
            yield return null;
        }
        _moveIndicator.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetUbication, 0.2f);
    }
}