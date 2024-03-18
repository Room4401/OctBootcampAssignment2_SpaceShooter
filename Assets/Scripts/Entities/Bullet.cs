using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 1f, speed = 10f, despawnTime = 3f;

    private float timer;
    private string targetTag;
    private void Update()
    {
        Move();
        timer += Time.deltaTime;
        if (timer > despawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetBullet(string _targetTag, float damage = 1f, float speed = 10f)
    {
        this.targetTag = _targetTag;
        this.damage = damage;
        this.speed = speed;
        timer = 0;
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);

            GameManager.GetInstance().scoreManager.IncrementScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }
        IDamageable damageable = collision.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
