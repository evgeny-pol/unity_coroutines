using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _counter.CounterChanged += OnCounterChanged;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= OnCounterChanged;
    }

    private void Start()
    {
        _text.text = _counter.Value.ToString();
    }

    public void OnCounterChanged(int value)
    {
        _text.text = value.ToString();
    }
}
