using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform player;


    public float mobSpeed = 4f;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private float attackDamage = 5;
    [SerializeField] private float attackRate = 1;
    private float nextAttackTime = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(player.position, gameObject.transform.position);

        if (dist > attackRange)
        {
            Vector3 direction = (player.position - gameObject.transform.position).normalized;

            transform.position += direction * mobSpeed * Time.deltaTime;
        }
        else
        {

            if (Time.time > nextAttackTime)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);

                    nextAttackTime = Time.time + (1 / attackRate);
                }
            }
        }
    }
}
