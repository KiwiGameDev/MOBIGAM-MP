﻿using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BulletMovement))]
public class Bullet : MonoBehaviour
{
    private BulletMovement movement = null;

    private void Awake()
    {
        movement = GetComponent<BulletMovement>();
    }

    public void Launch(Vector3 direction, int layer)
    {
        movement.Launch(direction);
        gameObject.layer = layer;
    }
}
