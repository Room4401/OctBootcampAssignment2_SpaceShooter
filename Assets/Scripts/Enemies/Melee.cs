using UnityEngine;

public class Melee : Enemy
{
    private float timer = 0f;

    private void Awake()
    {
        base.Start();
        health = new Health(stats.maxHealth);
        SetEnemyType(EnemyType.Melee);
    }

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < stats.range)
        {
            Turn(target.position);
            Attack(stats.attackRate);
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
            target.GetComponent<IDamageable>().GetDamage(stats.damage);
        }
    }
}