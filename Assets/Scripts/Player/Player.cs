using UnityEngine;

public class Player : Moveable
{
    [SerializeField] private float maxHealth = 100f, regenRate = 1f, weaponDamage = 1f, bulletSpeed = 10f;
    [SerializeField] private Camera cam;
    [SerializeField] private Bullet bulletPrefab;

    private Rigidbody2D playerRB;

    private void Start()
    {
        this.playerRB = GetComponent<Rigidbody2D>();
        this.health = new Health(maxHealth, regenRate);
        this.weapon = new Weapon(weaponDamage, bulletSpeed);
    }

    private void Update()
    {
        health.RegenHealth();
    }

    public override void Move(Vector2 _direction, Vector2 _target)
    {
        playerRB.velocity = _direction * speed * Time.deltaTime;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);

        _target.x -= playerScreenPos.x;
        _target.y -= playerScreenPos.y;
        float angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Enemy");
    }

    public override void GetDamage(float _damage)
    {
        base.GetDamage(_damage);

    }
}