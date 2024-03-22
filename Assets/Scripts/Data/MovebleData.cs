using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Moveable Object Data", menuName = "Data/MoveableData", order = 1)]
public class MovebleData : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHealth = 1f;
    public float regenRate = 0f;
    public float speed = 1f;

    [Header("Attack Stats")]
    public float bulletSpeed = 10f;
    public float damage = 1f;
    public float attackRate = 1f;
    public float range = 1f;
}
