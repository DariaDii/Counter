using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    private float _currentValue;
    private float _delay = 0.5f;
    private bool _isEnabled = false;

    private WaitForSeconds _waitForSeconds;

    public event Action<float> Changed;

    private Coroutine _coroutine;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        Changed?.Invoke(_currentValue);
        
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Switch);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Switch);
    }

    private void Switch()
    {
        if (_isEnabled)
        {
            _isEnabled = false;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
        else
        {
            _isEnabled = true;
            _coroutine = StartCoroutine(Counting());
        }            
    }

    private IEnumerator Counting()
    {
        while (_isEnabled)
        {
            yield return _waitForSeconds;

            _currentValue++;
            Changed?.Invoke(_currentValue);
        }
    }
}
