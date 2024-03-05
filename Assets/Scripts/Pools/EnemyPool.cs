using System;

public class EnemyPool : Pool<Enemy>
{
    private BulletSpawner _bulletSpawner;

    public void Initialize(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    protected override void OnCreateObject(Enemy enemy)
    {
        enemy.Initialize(_bulletSpawner, this);
    }
}
