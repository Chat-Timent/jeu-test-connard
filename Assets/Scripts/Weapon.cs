using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    public Transform cameraTransform;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float damage = 10;
    [SerializeField] private float fireRate = 3;
    private float nextFireTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + (1 / fireRate);
                Debug.Log("jpeux tirer à " + Time.time);
            }
        }
    }

    void Fire()
    {
        Vector3 origin = cameraTransform.position;
        Vector3 direction = cameraTransform.forward; // pas de .transform car c'est déjà un transform en soi
        RaycastHit hit;

        Vector3 tracerPos =
            origin
            + cameraTransform.right * 2f
            - cameraTransform.up * 1f;
        

        lineRenderer.SetPosition(0, tracerPos);
        if (Physics.Raycast(origin, direction, out hit, 100))
        {
            lineRenderer.SetPosition(1, hit.point);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("ennemi touche");
            }
            else
            {
                Debug.Log("Objet random");
            }
        }
        else
        {
            lineRenderer.SetPosition(1, origin + direction * 100);
        }
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.enabled = true;
        StartCoroutine(HideTracer());
    }

    IEnumerator HideTracer()
    {
        yield return new WaitForSeconds(0.1f);
        lineRenderer.enabled = false;
    }
}
