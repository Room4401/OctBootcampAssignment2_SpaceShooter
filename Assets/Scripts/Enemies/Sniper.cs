using UnityEngine;

public class Sniper : Enemy
{
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private LineRenderer aimLine;
    private void Awake()
    {
        base.Start();
        health = new Health(stats.maxHealth);
        weapon = new Weapon(stats.damage, stats.bulletSpeed);
        aimLine = GetComponentInChildren<LineRenderer>();
        SetEnemyType(EnemyType.Sniper);
    }

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < stats.range)
        {
            aimLine.enabled = true;
            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, target.position);
            Turn(target.position);
            Attack(stats.attackRate);
        }
        else
        {
            aimLine.enabled = false;
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
            weapon.Shoot(bulletPrefab, this, "Player");
        }
    }
}