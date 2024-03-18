using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public virtual void OnPicked()
    {
        Destroy(gameObject);
    }
}