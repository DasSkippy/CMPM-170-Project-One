using UnityEngine;

public class DamageBar : MonoBehaviour
{
    public Transform healthMeter;
    private DamageBehavior damageBehavior;

    private float maxHealth = 100f;

    private void Start()
    {
        damageBehavior = FindFirstObjectByType<DamageBehavior>();
    }

    private void Update()
    {
        SetHealthBar();
        //Debug
        if (Input.GetKeyDown(KeyCode.H))
        {
            damageBehavior.TakeDamage();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Heal(20f);
        }
    }

    private void SetHealthBar()
    {
        float healthScalex = 6.4f * (damageBehavior.health / maxHealth);
        if (healthScalex > 6.4f)
            healthScalex = 6.4f;
        healthMeter.localScale = new Vector3 (6.4f * (damageBehavior.health / maxHealth), 1f, 1f);
    }

    public void Heal(float healAmount)
    {
        damageBehavior.Heal(healAmount);
        if (damageBehavior.health > maxHealth)
            damageBehavior.health = (int)maxHealth;
    }
}
