using UnityEngine;

public class Enemy : Moveable
{
    private EnemyType type;
    protected Transform target;

    protected virtual void Start()
    {
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
            Move(speed);
        }
    }
    protected override void Move(float _speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected override void Move(Vector2 _target)
    {
        Turn(_target);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected void Turn(Vector2 _target)
    {
        _target.x -= transform.position.x;
        _target.y -= transform.position.y;
        float angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected void SetEnemyType(EnemyType _type)
    {
        type = _type;
    }

    public EnemyType GetEnemyType()
    {
        return type;
    }
}