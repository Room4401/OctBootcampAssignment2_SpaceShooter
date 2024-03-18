using UnityEngine;

public class Exploder : Enemy
{
    [SerializeField] private float explosionRange = 0.2f, damage = 10f;

    private void Awake()
    {
        base.Start();
        health = new Health(1);
        SetEnemyType(EnemyType.Exploder);
        Debug.Log(GetEnemyType().ToString());
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < explosionRange)
        {
            target.GetComponent<IDamageable>().GetDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void SetExploderEnemy(float _explosionRange = 0.2f, float _damage = 10f)
    {
        this.explosionRange = _explosionRange;
        this.damage = _damage;
    }
}