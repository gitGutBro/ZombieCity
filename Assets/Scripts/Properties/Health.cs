using System;
using UnityEngine;

public class Health
{
    private const int Min = 0;

    private int _current;

    public int Max { get; private set; }

    public Health(int max)
    {
        if (max < 0)
            throw new ArgumentException(nameof(max));

        Max = max;
        _current = max;
    }
    
    public event Action Died;
    public event Action<int, int> Changed;

    public int Current => _current;

    public void OnValidate()
    {
        if (_current > Max)
            _current = Max;
    }

    public void Increase(int heal)
    {
        if (heal <= 0)
        {
            Debug.LogError($"Value heal is zero or less! {GetType()}");
            return;
        }

        _current = Mathf.Clamp(_current + heal, Min, Max);

        Changed?.Invoke(_current, Max);
    }

    public void Decrease(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogError($"Value damage is zero or less! {GetType()}");
            return;
        }

        _current = Mathf.Clamp(_current - damage, Min, Max);

        if (_current <= Min)
        {
            Died?.Invoke();
            return;
        }

        Changed?.Invoke(_current, Max);
    }
}