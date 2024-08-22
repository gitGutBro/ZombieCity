using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _valueView;
    [SerializeField] private TMP_Text _value; 

    private Health _health;

    private void OnDisable() => 
        _health.Changed -= OnHealthChanged;

    public void Init(Health health)
    {
        _health = health ?? throw new System.ArgumentNullException(nameof(health));
        _health.Changed += OnHealthChanged;

        OnHealthChanged(health.Current, health.Max);
    }

    private void OnHealthChanged(int health, int max)
    {
        _value.text = $"{health:F0}/{max:F0}";

        if (max < 0)
        {
            Debug.LogError($"Value max below zero! {GetType()}");
            return;
        }

        _valueView.fillAmount = (float)health / max;
    }
}