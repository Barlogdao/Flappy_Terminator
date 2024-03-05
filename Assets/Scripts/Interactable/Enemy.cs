using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _shootMinCooldown;
    [SerializeField] private float _shootMaxCooldown;
    [SerializeField] private Weapon _weapon;

    private EnemyPool _pool;
    private Coroutine _shootRoutine;

    public event Action<Enemy> Died;

    private Vector2 ShootDirection => Vector2.zero;

    public void Initialize(BulletSpawner bulletSpawner, EnemyPool pool)
    {
        _pool = pool;
        _weapon.Initialize(bulletSpawner);
    }

    private void OnEnable()
    {
        if (_shootRoutine != null)
            StopCoroutine(_shootRoutine);

        _shootRoutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shootRoutine);
    }

    public void Remove()
    {
        Died?.Invoke(this);
        _pool.PutObject(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            bullet.Remove();
            Remove();
        }
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds cooldown = new WaitForSeconds(UnityEngine.Random.Range(_shootMinCooldown, _shootMaxCooldown));

        while (enabled)
        {
            yield return cooldown;

            _weapon.Shoot(ShootDirection);
        }
    }
}
