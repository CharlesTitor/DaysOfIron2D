//Tutorial video: https://www.youtube.com/watch?v=Eg7oP7mcNbc

using UnityEngine;

public interface IInteractable
{
    public bool CanInteract(IInteractor interactor);
    public void Interact(IInteractor interactor);
}
