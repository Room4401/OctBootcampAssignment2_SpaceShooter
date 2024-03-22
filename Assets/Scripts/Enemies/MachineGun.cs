using UnityEngine;

public class MachineGun : Enemy
{
    [SerializeField] private float aimRecoil = 50f;
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private void Awake()
    {
        base.Start();
        health = new Health(stats.maxHealth);
        weapon = new Weapon(stats.damage, stats.bulletSpeed);
        SetEnemyType(EnemyType.MachineGun);
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
            weapon.Shoot(bulletPrefab, this, "Player", aimRecoil);
        }
    }
}