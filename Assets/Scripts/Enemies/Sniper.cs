using UnityEngine;

public class Sniper : Enemy
{
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private LineRenderer aimLine;
    private void Awake()
    {
        base.Start();
        health = new Health(1);
        weapon = new Weapon(damage, bulletSpeed);
        aimLine = GetComponent<LineRenderer>();
        SetEnemyType(EnemyType.Sniper);
    }

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            aimLine.enabled = true;
            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, target.position);
            Turn(target.position);
            Attack(attackRate);
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

    public void SetSniperEnemy(float _attackRange = 7f, float _chargeRate = 2f, float _damage = 20f, float _bulletSpeed = 20f)
    {
        bulletSpeed = _bulletSpeed;
        attackRange = _attackRange;
        attackRate = _chargeRate;
        damage = _damage;
    }
}