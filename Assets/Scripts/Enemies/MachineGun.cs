using UnityEngine;

public class MachineGun : Enemy
{
    [SerializeField] private float fireRate = 0.1f, aimRecoil = 30f, attackRange = 5f, damage = 1f;
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private void Awake()
    {
        base.Start();
        this.health = new Health(1);
        this.weapon = new Weapon(damage, bulletSpeed);
        SetEnemyType(EnemyType.MachineGun);
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
            Attack(fireRate);
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

    public void SetMachineGunEnemy(float _attackRange = 2f, float _fireRate = 2f, float _recoilAngle = 30f, float _damage = 1f)
    {
        this.attackRange = _attackRange;
        this.aimRecoil = _recoilAngle;
        this.fireRate = _fireRate;
        this.damage = _damage;
    }
}