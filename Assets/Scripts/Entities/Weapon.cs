using UnityEngine;

public class Weapon
{
    private float damage, bulletSpeed;

    public Weapon(float _damage, float _bulletSpeed)
    {
        this.damage = _damage;
        this.bulletSpeed = _bulletSpeed;
    }

    public void Shoot(Bullet _bullet, Moveable _shooter, string _targetTag, float _despawnTime = 5f)
    {
        Bullet tempBullet = GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);
        tempBullet.SetBullet(_targetTag, damage, bulletSpeed);

        GameObject.Destroy(tempBullet.gameObject, _despawnTime);
    }
}