using UnityEngine;

public class HealBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            Heal(20f);
            Destroy(gameObject);
        }
    }
    public void Heal(float healAmount)
    {
        DamageBehavior damageBehavior = FindFirstObjectByType<DamageBehavior>();
        if (damageBehavior != null)
        {
            damageBehavior.health += (int)healAmount;
        }
    }
}