using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        Debug.Log("Le joueur a " + health + " HP");

        if (health <= 0)
        {
            Debug.Log("ah jsuis mort");
        }
    }
}
