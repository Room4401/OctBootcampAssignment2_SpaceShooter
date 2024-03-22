using UnityEngine;

public class Weapon
{
    private float damage, bulletSpeed;

    public Weapon(float _damage, float _bulletSpeed)
    {
        this.damage = _damage;
        this.bulletSpeed = _bulletSpeed;
    }

    public void Shoot(Bullet _bullet, Moveable _shooter, string _targetTag, float _recoilAngle = 0f, float _despawnTime = 3f)
    {
        Quaternion angle = _shooter.transform.rotation * Quaternion.Euler(0, 0, Random.Range(-_recoilAngle / 2, _recoilAngle / 2));
        Bullet tempBullet = GameObject.Instantiate(_bullet, _shooter.transform.position, angle);
        tempBullet.SetBullet(_targetTag, damage, bulletSpeed);

        GameObject.Destroy(tempBullet.gameObject, _despawnTime);
    }
}