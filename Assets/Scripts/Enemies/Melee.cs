using UnityEngine;

public class Melee : Enemy
{
    private float timer = 0f;

    private void Awake()
    {
        base.Start();
        health = new Health(1);
        SetEnemyType(EnemyType.Melee);
    }

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Turn(target.position);
            Attack(attackRate);
        }
        else
        {
            base.Update();
            timer = 0;
        }
    }

    private void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(damage);
        }
    }

    public void SetMeleeEnemy(float _attackRange = 0.2f, float _attackRate = 2f, float _damage = 5f)
    {
        attackRange = _attackRange;
        attackRate = _attackRate;
        damage = _damage;
    }
}