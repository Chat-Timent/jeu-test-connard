using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;

    public float moveSpeed = 7f;

    private CharacterController controller;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
