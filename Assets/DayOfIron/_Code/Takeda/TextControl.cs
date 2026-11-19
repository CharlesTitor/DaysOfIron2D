using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("The UI element to control")]
    [SerializeField] private GameObject _textElement;
    private CanvasGroup _uIGroup;
    private TMP_Text _text;
    [Header("List of texts to display")]
    [SerializeField] private string[] _textList;
    [Header("Parameters for fade transitions")]
    [SerializeField] private float _transitionInterval;
    [SerializeField] private float _transitionDuration;
    [Header("The mask for progress bar")]
    [SerializeField] private Image _mask;
    private int _fadeCount;
    private float _timer;
    private FadeState _currentFadeState;
    private enum FadeState
    {
        Neutral,
        FadeOut,
        FadeIn
    }
    void Start()
    {
        _uIGroup = _textElement.GetComponent<CanvasGroup>();
        _text = _textElement.GetComponent<TMP_Text>();
        _fadeCount = 0;
        _timer = 0f;
        _currentFadeState = FadeState.Neutral;
        try
        {
            _text.text = _textList[0];
        }catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Update()
    {
        Debug.Log(_fadeCount+" "+_currentFadeState+" "+_timer);
        if (_fadeCount >= _textList.Length) { return; }
        _timer += Time.deltaTime;
        switch (_currentFadeState)
        {
            case FadeState.Neutral:
                if (_timer >= _transitionInterval*(_fadeCount+1) && _timer < _transitionInterval * (_fadeCount + 2))
                {
                    _currentFadeState++;
                    _fadeCount++;
                }
                break;
            case FadeState.FadeOut:
                _uIGroup.alpha -= Time.deltaTime / _transitionDuration;
                if (_uIGroup.alpha <= 0) {
                    _currentFadeState++;
                    /*switch (_fadeCount)
                    {
                        case 0:
                            _text.text = "";
                            break;
                        case 1:
                            _text.text = "Ve a casa";
                            _text.horizontalAlignment = HorizontalAlignmentOptions.Center;
                            break;
                    }*/
                    _text.text = _textList[_fadeCount];
                    if (_fadeCount == _textList.Length-1)
                    {
                        _text.horizontalAlignment = HorizontalAlignmentOptions.Center;
                    }
                }
                break;
            case FadeState.FadeIn:
                _uIGroup.alpha += Time.deltaTime / _transitionDuration;
                if (_uIGroup.alpha >= 1) {
                    _currentFadeState = FadeState.Neutral;
                }
                break;
        }
        Math.Clamp(_uIGroup.alpha, 0, 1);
        _mask.fillAmount = (_timer - _transitionInterval * _fadeCount) / _transitionInterval;
    }

    public void GoToNextText()
    {
        Debug.Log("NextButtonPressed");
        _timer += _transitionInterval;
        //_fadeCount++;
        _currentFadeState = FadeState.FadeOut;
    }

}
