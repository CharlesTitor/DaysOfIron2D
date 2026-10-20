using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D _cursorTexture;
    [SerializeField] private Texture2D _interactTexture;
    [SerializeField] private Texture2D _talkTexture;
    [SerializeField] private Texture2D _forbiddenTexture;

    private Vector2 _cursorHotSpot;

    public enum CursorType
    {
        Default,
        Interactable,
        Talk,
        Forbidden
    }

    private void Awake()
    {
        Instance = this;
    }

    public void SetActiveCursorType(CursorType cursorType)
    {
        switch (cursorType)
        {
            case CursorType.Default:
                _cursorHotSpot = new Vector2(0f, 0f);
                Cursor.SetCursor(_cursorTexture, _cursorHotSpot, CursorMode.Auto);
                break;
            case CursorType.Interactable:
                _cursorHotSpot = new Vector2(_interactTexture.width / 3,_interactTexture.height / 3);
                Cursor.SetCursor(_interactTexture, _cursorHotSpot, CursorMode.Auto);
                break;
            case CursorType.Talk:
                _cursorHotSpot = new Vector2(0f,_talkTexture.height);
                Cursor.SetCursor(_talkTexture, _cursorHotSpot, CursorMode.Auto);
                break;
            case CursorType.Forbidden:
                _cursorHotSpot=new Vector2(_forbiddenTexture.width/2,_forbiddenTexture.height/2);
                Cursor.SetCursor(_forbiddenTexture, _cursorHotSpot, CursorMode.Auto);
                break;
        }
    }

    void Start()
    {
        Cursor.SetCursor(_cursorTexture, _cursorHotSpot, CursorMode.Auto);
    }
}
