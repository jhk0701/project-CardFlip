using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(EventTrigger))]
public class Flinch : MonoBehaviour
{
    private bool _hasTransform = false;

    private Transform _transform = null;

    private Transform getTransform {
        get
        {
            if(_hasTransform == false)
            {
                _hasTransform = true;
                _transform = transform;
            }
            return _transform;
        }
    }

    private bool _hasButton = false;

    private Button _button = null;

    private Button getButton {
        get
        {
            if(_hasButton == false)
            {
                _hasButton = true;
                _button = GetComponent<Button>();
            }
            return _button;
        }
    }

    [SerializeField]
    private float _duration = 1.0f;

    [SerializeField]
    private Vector2 _expandSize = new Vector2(1.0f, 1.0f);

    private Vector2 _originalScale;

    private void Start()
    {
        _originalScale = getTransform.localScale;
    }

    private IEnumerator DoFlinch()
    {
        getTransform.localScale = _originalScale;
        float time = 0;
        while(time < _duration * 0.5f)
        {
            float deltaTime = Time.deltaTime;
            time += deltaTime;
            getTransform.localScale = _originalScale + (_expandSize * time * 2);
            yield return null;
        }
        while (time > 0)
        {
            float deltaTime = Time.deltaTime;
            time -= deltaTime;
            getTransform.localScale = _originalScale + (_expandSize * time * 2);
            yield return null;
        }
        getTransform.localScale = _originalScale;
    }


    public void Play()
    {
        if (getButton.interactable == true)
        {
            StopAllCoroutines();
            StartCoroutine(DoFlinch());
        }
    }
}
