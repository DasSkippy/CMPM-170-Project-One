using UnityEngine;

public class DamageBar : MonoBehaviour
{
    public Transform healthMeter;
    private DamageBehavior damageBehavior;
    private GameManager gameManager;

    private bool lost;

    private float maxHealth = 100f;

    private void Start()
    {
        damageBehavior = FindFirstObjectByType<DamageBehavior>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        SetHealthBar();
        if(damageBehavior.health >= maxHealth)
        {
            damageBehavior.health = maxHealth;
        } else if (damageBehavior.health <= 0 && !lost)
        {
            lost = true;
            damageBehavior.health = 0;
            gameManager.Lose(1);
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
