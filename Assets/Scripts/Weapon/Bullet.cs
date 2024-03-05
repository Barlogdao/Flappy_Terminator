using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IInteractable
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BulletPool _pool;

    public void Initialize(BulletPool pool)
    {
        _pool = pool;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Prepare(Vector2 direction, Color color, float speed, LayerMask ignoreLayer)
    {
        _spriteRenderer.color = color;
        _rigidbody2D.velocity = direction.normalized * speed;
        _rigidbody2D.excludeLayers = ignoreLayer;
    }

    public void Remove()
    {
        _pool.PutObject(this);
    }
}
