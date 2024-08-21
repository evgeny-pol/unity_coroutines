using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public event UnityAction<int> CounterChanged;

    [SerializeField, Min(0)] private float _incrementInterval;
    [SerializeField, Min(1)] private int _incrementValue;

    private int _value;
    private Coroutine _counterCoroutine;

    public int Value => _value;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_counterCoroutine == null)
            {
                _counterCoroutine = StartCoroutine(DoCounting());
            }
            else
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator DoCounting()
    {
        var incrementInterval = new WaitForSeconds(_incrementInterval);

        while (true)
        {
            _value += _incrementValue;
            CounterChanged?.Invoke(_value);
            yield return incrementInterval;
        }
    }
}
