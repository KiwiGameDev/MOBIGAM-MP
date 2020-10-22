﻿using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private Transform target = null;

    [Header("Settings")]
    [SerializeField] private Vector2 cooldownRange = new Vector2(1f, 2f);
    [SerializeField, Range(0, 1)] private float hitChance = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(ShootingLoop());
    }

    private IEnumerator ShootingLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(cooldownRange.x, cooldownRange.y));
            if (Random.value < hitChance)
                ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Vector3 direction = (target.position - bulletSpawnPoint.position).normalized;
        bullet.Launch(direction, gameObject.layer);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
