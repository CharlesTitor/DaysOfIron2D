using UnityEngine;

public class KaelAnimations : MonoBehaviour
{
    [SerializeField] private float _movementThreshold = 0.05f;
    [SerializeField] private float _idleDelay = 0.1f;

    private static readonly int _isWalkingHash = Animator.StringToHash("IsWalking");

    private Animator _kaelAnimator;
    private SpriteRenderer _kaelSprite;
    private Vector3 _lastPosition;
    private float _idleTimer;
    private bool _isWalking;

    private void Awake()
    {
        _kaelAnimator = GetComponent<Animator>();
        _kaelSprite = GetComponent<SpriteRenderer>();
        _lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 movement = transform.position - _lastPosition;
        float movementSpeed = movement.magnitude / Time.deltaTime;

        if (movementSpeed > _movementThreshold)
        {
            _idleTimer = 0f;
            SetWalking(true);

            if (Mathf.Abs(movement.x) > _movementThreshold * Time.deltaTime) { _kaelSprite.flipX = movement.x < 0; }
        }
        else
        {
            _idleTimer += Time.deltaTime;

            if (_idleTimer >= _idleDelay) { SetWalking(false); }
        }

        _lastPosition = transform.position;

    }

    private void SetWalking(bool isWalking)
    {
        if (_isWalking == isWalking) { return; }

        _isWalking = isWalking;
        _kaelAnimator.SetBool(_isWalkingHash, _isWalking);
    }
}