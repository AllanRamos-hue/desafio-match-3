using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] bool _startOn;
    [SerializeField] float _fadeTime = 0.05f;
    [Space]

    CanvasGroup _myCanvasGroup;

    bool _isFading;
    bool _isFadedIn;
    float _currentFadeTime;
    float _percOfFade;

    void Awake()
    {
        _myCanvasGroup = this.GetComponent<CanvasGroup>();

        _isFading = false;

        _myCanvasGroup.alpha = (_startOn) ? 1 : 0;
        _myCanvasGroup.interactable = _startOn;
        _myCanvasGroup.blocksRaycasts = _startOn;
        _isFadedIn = _startOn;
    }

    public void DoFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void DoFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        _isFading = true;
        _currentFadeTime = _myCanvasGroup.alpha * _fadeTime;
        _percOfFade = _currentFadeTime / _fadeTime;

        while (_isFading)
        {
            yield return null;

            _currentFadeTime += Time.deltaTime;
            if (_currentFadeTime > _fadeTime)
            {
                _currentFadeTime = _fadeTime;
                _isFading = false;
            }

            _percOfFade = _currentFadeTime / _fadeTime;
            _myCanvasGroup.alpha = Mathf.Lerp(0, 1, _percOfFade);
        }

        _isFadedIn = true;
        _myCanvasGroup.interactable = true;
        _myCanvasGroup.blocksRaycasts = true;
    }

    private IEnumerator FadeOut()
    {
        _isFading = true;

        _currentFadeTime = (1 - _myCanvasGroup.alpha) * _fadeTime;
        _percOfFade = _currentFadeTime / _fadeTime;

        _myCanvasGroup.interactable = false;
        _myCanvasGroup.blocksRaycasts = false;

        while (_isFading)
        {
            yield return null;

            _currentFadeTime += Time.deltaTime;
            if (_currentFadeTime > _fadeTime)
            {
                _currentFadeTime = _fadeTime;
                _isFading = false;
            }

            _isFadedIn = false;
            _percOfFade = _currentFadeTime / _fadeTime;
            _myCanvasGroup.alpha = Mathf.Lerp(1, 0, _percOfFade);
        }
    }
}