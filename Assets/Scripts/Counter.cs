using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _incrementInterval;
    [SerializeField, Min(1)] private int _incrementValue;
    [SerializeField] private Text _counterText;

    private Coroutine _counterCoroutine;

    private void Start()
    {
        _counterText.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_counterCoroutine == null)
            {
                _counterCoroutine = StartCoroutine(CounterCoroutine());
                return;
            }
            else
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator CounterCoroutine()
    {
        var incrementInterval = new WaitForSeconds(_incrementInterval);

        while (true)
        {
            int.TryParse(_counterText.text, out int currentValue);
            _counterText.text = (currentValue + _incrementValue).ToString();
            yield return incrementInterval;
        }
    }
}
