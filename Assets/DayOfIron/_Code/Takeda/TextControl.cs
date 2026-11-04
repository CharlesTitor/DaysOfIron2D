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
    [Header("Parameters for fade transitions")]
    [SerializeField] private float _transitionInterval;
    [SerializeField] private float _transitionDuration;
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
    }

    void Update()
    {
        Debug.Log(_fadeCount+" "+_currentFadeState+" "+_timer);
        if (_fadeCount >= 2) { return; }
        _timer += Time.deltaTime;
        switch (_currentFadeState)
        {
            case FadeState.Neutral:
                if (_timer >= _transitionInterval*(_fadeCount+1) && _timer < _transitionInterval * (_fadeCount + 2))
                {
                    _currentFadeState++;
                }
                break;
            case FadeState.FadeOut:
                _uIGroup.alpha -= Time.deltaTime / _transitionDuration;
                if (_uIGroup.alpha <= 0) {
                    _currentFadeState++;
                    switch (_fadeCount)
                    {
                        case 0:
                            _text.text = "Allí vive Kael, un joven aprendiz de herrero que trabaja junto a su padre, Marek.\r\n\r\nSus días transcurren entre el fuego de la fragua, el sonido del martillo y las necesidades de sus vecinos. Repara herramientas, recupera metal y aprende a distinguir lo que todavía puede salvarse de aquello que debe abandonarse.\r\n\r\nPara Kael, el hierro es algo que sirve para construir.\r\n\r\nPero fuera de Yunque Rojo, otros han aprendido a utilizarlo para gobernar.\r\n\r\nY pronto descubrirá que incluso las manos que enseñan a construir pueden guardar secretos sobre aquello que alguna vez destruyeron.";
                            break;
                        case 1:
                            _text.text = "Ve a casa";
                            _text.horizontalAlignment = HorizontalAlignmentOptions.Center;
                            break;
                    }
                }
                break;
            case FadeState.FadeIn:
                _uIGroup.alpha += Time.deltaTime / _transitionDuration;
                if (_uIGroup.alpha >= 1) {
                    _currentFadeState = FadeState.Neutral;
                    _fadeCount++;
                }
                break;
        }
        Math.Clamp(_uIGroup.alpha, 0, 1);
    }
}
