using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootingRange = 50f;
    public LayerMask enemyLayer;
    public Animator animator;

    private Camera ethansEyes;
    private bool isScoped = false;

    void Start()
    {
        ethansEyes= GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (animator == null)
        {
            Debug.LogError("Animator component not assigned!");
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button is for shooting
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            ToggleScope();
        }
    }

    void Shoot()
    {
        Ray ray = ethansEyes.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingRange, enemyLayer))
        {
            if (hit.collider.CompareTag("EnemyUnarmed") || hit.collider.CompareTag("EnemyArmed"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage();
                }
            }
        }
    }
    void ToggleScope()
    {
        isScoped = !isScoped;
        animator.SetBool("Scope", isScoped);
    }
}
