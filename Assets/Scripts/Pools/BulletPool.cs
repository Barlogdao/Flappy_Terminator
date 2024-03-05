public class BulletPool : Pool<Bullet>
{
    protected override void OnCreateObject(Bullet bullet)
    {
        bullet.Initialize(this);
    }
}