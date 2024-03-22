using UnityEngine;

public class Enemy : Moveable
{
    private EnemyType type;
    protected Transform target;
    [SerializeField] Vector3 currentPostion;
    protected virtual void Start()
    {
        GameManager.enemyCount++;
        target = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(stats.speed);
        }
    }
    protected override void Move(float _speed)
    {
        transform.Translate(Vector2.right * stats.speed * Time.deltaTime);
    }

    protected override void Move(Vector2 _target)
    {
        Turn(_target);
        transform.Translate(Vector2.right * stats.speed * Time.deltaTime);
    }

    protected void Turn(Vector2 _target)
    {
        _target.x -= transform.position.x;
        _target.y -= transform.position.y;
        float angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Die()
    {
        GameManager.GetInstance().dropItem.SpawnPickUp(transform.position);
        GameManager.GetInstance().scoreManager.IncrementScore();
        base.Die();
    }

    protected void SetEnemyType(EnemyType _type)
    {
        type = _type;
    }

    public EnemyType GetEnemyType()
    {
        return type;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}