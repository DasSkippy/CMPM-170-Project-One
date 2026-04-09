using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    int health = 100;
    int damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Debug.Log(collision.gameObject.name);
            health -= damage;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            Debug.Log("You Lose");
        }
    }
}
