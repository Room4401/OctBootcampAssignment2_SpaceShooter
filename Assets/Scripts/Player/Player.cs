using UnityEngine;
using UnityEngine.UI;

public class Player : Moveable
{
    [SerializeField] private Camera cam;
    [SerializeField] private Bullet bulletPrefab;

    private Rigidbody2D playerRB;
    private Image buffClock;
    private float buffTimer, buffDuration, shootTimer, buffRate, nukeCount;
    private bool isBuffOn;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        buffClock = GetComponentInChildren<Image>();
        health = new Health(stats.maxHealth, stats.regenRate);
        weapon = new Weapon(stats.damage, stats.bulletSpeed);
    }

    private void Update()
    {
        health.RegenHealth();
        SetBuffTimer();
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    public override void Move(Vector2 _direction, Vector2 _target)
    {
        playerRB.velocity = _direction * stats.speed;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);

        _target.x -= playerScreenPos.x;
        _target.y -= playerScreenPos.y;
        float angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        if (shootTimer <= 0)
        {
            weapon.Shoot(bulletPrefab, this, "Enemy");
            if (isBuffOn)
            {
                shootTimer = buffRate;
            }
            else
            {
                shootTimer = stats.attackRate;
            }
        }
    }

    public float ShowNuke()
    {
        return nukeCount;
    }

    public void AddNuke()
    {
        if (nukeCount < 5)
        {
            nukeCount++;
        }
    }

    public void UseNuke()
    {
        if (nukeCount > 0)
        {
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().Die();
            }
            nukeCount--;
        }
    }

    private void SetBuffTimer()
    {
        if (buffTimer > 0 && buffDuration > 0)
        {
            buffClock.fillAmount = buffTimer / buffDuration;
            buffTimer -= Time.deltaTime;
        }
        if (buffTimer <= 0)
        {
            isBuffOn = false;
        }
    }

    public void StartBuff(float _duration, float _buffRate)
    {
        buffTimer = _duration;
        buffDuration = _duration;
        buffRate = _buffRate;
        isBuffOn = true;
    }

    public bool BuffStatus()
    {
        return isBuffOn;
    }
}