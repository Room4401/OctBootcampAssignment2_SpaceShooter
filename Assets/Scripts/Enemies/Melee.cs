using UnityEngine;

public class Melee : Enemy
{
    [SerializeField] private float attackRange = 0.2f, attackSpeed = 2f, damage = 1f;

    private float timer = 0f;

    private void Awake()
    {
        base.Start();
        health = new Health(1);
        SetEnemyType(EnemyType.Melee);
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack(attackSpeed);
        }
        else
        {
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

    public void SetMeleeEnemy(float _attackRange = 0.2f, float _attackTime = 2f, float _damage = 1f)
    {
        this.attackRange = _attackRange;
        this.attackSpeed = _attackTime;
        this.damage = _damage;
    }
}