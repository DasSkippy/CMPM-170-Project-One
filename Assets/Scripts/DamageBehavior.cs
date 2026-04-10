using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    public int health = 100;
    int damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Debug.Log(collision.gameObject.name);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= damage;
    }

    private void Update()
    {
        if(health <= 0)
        {
            //Car Destroyed
            Debug.Log("You Lose");
        }
    }
}
