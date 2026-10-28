// Tutorial video: https://www.youtube.com/watch?v=Eg7oP7mcNbc

using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour , IInteractor
{
     [SerializeField] private float _castDistance = 5f;
    [SerializeField] private Vector3 _raycastOffset = new Vector3(0, 0.3f, 0);

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Interact");

            if (DoInteractionTest(out IInteractable interactable))
            {
                if(interactable.CanInteract(this))
                {
                    interactable.Interact(this);
                }
            }
        }
    }

    private bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;

        Ray ray = new Ray(transform.position + _raycastOffset, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInformation, _castDistance))
        {
            interactable = hitInformation.collider.GetComponent<IInteractable>();

            if( interactable != null )
            {
                return true;
            }
            else { return false; }
        }
        else { return false; }
    }

}
