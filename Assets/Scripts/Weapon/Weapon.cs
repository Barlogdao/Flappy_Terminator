using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] private Color _bulletColor;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private LayerMask _ignoreLayer;

    private BulletSpawner _bulletSpawner;

    public void Initialize(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    public void Shoot(Vector2 shootDirection)
    {
        Bullet bullet = _bulletSpawner.Spawn(_shootPoint.position);

        bullet.Prepare(shootDirection, _bulletColor, _shootSpeed, _ignoreLayer);
    }
}
