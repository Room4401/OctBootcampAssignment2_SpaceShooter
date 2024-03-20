using UnityEngine;

public class Exploder : Enemy
{
    private void Awake()
    {
        base.Start();
        health = new Health(1);
        SetEnemyType(EnemyType.Exploder);
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
            target.GetComponent<IDamageable>().GetDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void SetExploderEnemy(float _explosionRange = 0.2f, float _damage = 40f)
    {
        attackRange = _explosionRange;
        damage = _damage;
    }
}