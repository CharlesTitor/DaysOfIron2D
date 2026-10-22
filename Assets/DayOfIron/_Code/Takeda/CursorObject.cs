using UnityEngine;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(Collider))]
//[RequireComponent (typeof(Rigidbody))]

public class CursorObject : MonoBehaviour
{
    //Color _startColor;
    private Material _originalMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _outlineMaterial;

    [SerializeField] private CursorManager.CursorType _cursorType;


    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            CursorManager.Instance.SetActiveCursorType(_cursorType);
            if (_cursorType == CursorManager.CursorType.Interactable)
            {
                //_startColor = _renderer.material.color;
                //_renderer.material.color = Color.yellow;
                _originalMaterial = _renderer.material;
                _renderer.material = _outlineMaterial;
            }
        }
    }


    private void OnMouseExit() => ReturnCursorToDefault();

    private void OnDestroy() => ReturnCursorToDefault();

    private void ReturnCursorToDefault()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Default);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            _renderer.material = _originalMaterial;
        }
    }

}
