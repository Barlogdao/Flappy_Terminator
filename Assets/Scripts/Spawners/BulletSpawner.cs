using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private BulletPool _bulletPool;

    public void Initialize(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Reset()
    {
        _bulletPool.Reset();
    }

    public Bullet Spawn(Vector2 spawnPosition)
    {
        Bullet bullet = _bulletPool.GetObjet();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPosition;

        return bullet;
    }
}
