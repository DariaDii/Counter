using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _counterText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += UpdateView;
    }

    private void OnDisable()
    {
        _counter.Changed -= UpdateView;
    }

    private void UpdateView(float value)
    {
        _counterText.text = value.ToString();
    }    
}
