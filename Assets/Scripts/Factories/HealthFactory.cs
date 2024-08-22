using UnityEngine;

public class HealthFactory
{
    private readonly HealthBar _healthBarPrefab;

    public HealthFactory(HealthBar healthBarPrefab) => 
        _healthBarPrefab = healthBarPrefab != null ? healthBarPrefab : throw new System.ArgumentNullException(nameof(healthBarPrefab));

    public Health Create(int maxHealth, Transform parentTransform)
    {
        Health health = CreateModel(maxHealth);
        CreateHealthBar(parentTransform, health);

        return health;
    }

    private Health CreateModel(int max) => 
        new(max);

    private void CreateHealthBar(Transform parentTransform, Health health)
    {
        HealthBar healthBar = GameObject.Instantiate(_healthBarPrefab, parentTransform);
        healthBar.Init(health);
        healthBar.transform.localPosition = Vector2.zero;
    }
}