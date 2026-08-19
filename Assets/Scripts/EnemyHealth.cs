using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public PlayerStats playerStats;

    public float health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // inflige des dégats au mob
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("L'ennemi " + gameObject.name + " a " + health + " HP maintenant");

        if (health <= 0)
        {
            Destroy(gameObject);
            playerStats.AddKill();
            playerStats.AddXp(20);
        }
    }
}
