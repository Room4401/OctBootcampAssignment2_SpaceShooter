using UnityEngine;

public class Sniper : Enemy
{
    [SerializeField] private float attackRange = 5f, chargeRate = 2f, damage = 1f, bulletSpeed = 10f;
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private LineRenderer aimLine;
    private void Awake()
    {
        base.Start();
        this.health = new Health(1);
        this.weapon = new Weapon(damage, bulletSpeed);
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
            Attack(chargeRate);
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

    public void SetMeleeEnemy(float _attackRange = 2f, float _chargeRate = 2f, float _damage = 1f)
    {
        this.attackRange = _attackRange;
        this.chargeRate = _chargeRate;
        this.damage = _damage;
    }
}