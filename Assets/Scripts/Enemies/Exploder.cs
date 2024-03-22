using UnityEngine;

public class Exploder : Enemy
{
    private void Awake()
    {
        base.Start();
        health = new Health(stats.maxHealth);
        SetEnemyType(EnemyType.Exploder);
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < stats.range)
        {
            target.GetComponent<IDamageable>().GetDamage(stats.damage);
            Destroy(this.gameObject);
        }
    }
}