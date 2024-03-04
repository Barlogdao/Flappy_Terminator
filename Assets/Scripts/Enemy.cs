using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(gameObject);
        }
    }
}
