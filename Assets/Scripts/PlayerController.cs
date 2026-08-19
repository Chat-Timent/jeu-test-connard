using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 7f;
    public float sprintSpeed = 12f;
    public float gravity = -20f;

    private CharacterController controller;
    private float verticalVelocity;


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

        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            input = new Vector2(
                Keyboard.current.qKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0,
                Keyboard.current.sKey.isPressed ? -1 : Keyboard.current.zKey.isPressed ? 1 : 0
                );
        }

        input = Vector2.ClampMagnitude(input, 1f);

        Vector3 move = transform.right * input.x + transform.forward * input.y; // on prend la direction où le perso regarde devant et sur le coté et on
        // multiplie ces valeurs pour savoir vers où avancer (par exemple si Z est appuyé et qu'on regarde plein nord ça fait (1, 0, 0) * 1 donc dans
        // le Vector3 qui représente la direction on a (1, 0 ,0) et même calcul pour les déplacements sur le coté

        // gravité
        if(controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        if(controller.isGrounded)
        {
            // jump
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                verticalVelocity = 10;
            }
        }

        verticalVelocity += gravity * Time.deltaTime;


        // mouvement horizontal + vertical + gestion du sprint (move x currentspeed = vitesse de déplacement)
        float currentSpeed;

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }


        Vector3 velocity = move * currentSpeed; // move (direction) * vitesse (selon sprint ou walk) à laquelle il se déplace chaque frame
        velocity.y = verticalVelocity;


        controller.Move(velocity * Time.deltaTime); // Time.deltaTime = temps écoulé depuis la dernière frame
    }
}