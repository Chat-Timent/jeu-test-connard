using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private int kills = 0;
    [SerializeField] private float currentXp = 0;
    [SerializeField] private float xpToNextLevel = 100;
    [SerializeField] private int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddKill()
    {
        kills += 1;
    }

    public void AddXp(float amount)
    {
        currentXp += amount;
        if (currentXp > xpToNextLevel)
        {
            level += 1;
            currentXp -= xpToNextLevel;
            xpToNextLevel *= level * 1.5f;
        }
    }
}
