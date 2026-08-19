using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{



    public Transform cameraTransform;
    public float mouseSensitivity = 0.15f;
    private float verticalRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        verticalRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = Vector2.zero;

        if (Mouse.current != null)
        {
            input = Mouse.current.delta.ReadValue();
        }

        transform.Rotate(0f, input.x * mouseSensitivity, 0f);
        verticalRotation -= input.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}