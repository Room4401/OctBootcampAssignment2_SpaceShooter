using UnityEngine;

public class MachineGun : Enemy
{
    [SerializeField] private float aimRecoil = 50f;
    [SerializeField] private Bullet bulletPrefab;

    private float timer = 0f;
    private void Awake()
    {
        base.Start();
        health = new Health(1);
        weapon = new Weapon(damage, bulletSpeed);
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
            weapon.Shoot(bulletPrefab, this, "Player", aimRecoil);
        }
    }

    public void SetMachineGunEnemy(float _attackRange = 5f, float _fireRate = 0.2f, float _recoilAngle = 50f, float _damage = 2f, float _bulletSpeed = 5f)
    {
        bulletSpeed = _bulletSpeed;
        attackRange = _attackRange;
        aimRecoil = _recoilAngle;
        attackRate = _fireRate;
        damage = _damage;
    }
}