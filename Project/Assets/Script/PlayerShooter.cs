using UnityEngine;
using System.Collections.Generic;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireTimer;
    private float baseFireRate;

    void Start()
    {
        baseFireRate = fireRate;
        fireRate = baseFireRate + PlayerUpgrades.Instance.dañoExtra;
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            GameObject target = FindClosestEnemy();
            if (target != null)
            {
                ShootAt(target.transform);
                fireTimer = 1f / fireRate;
            }
        }
    }

    void ShootAt(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}

