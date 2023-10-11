using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTest : MonoBehaviour
{

    public List<ObjectInfo> objectInfos;

    private void Start()
    {
        Debug.Log(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector3)));
        Debug.Log(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Color)));
        Debug.Log(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Enemy)));
    }

    // Zamislite da je ovo BULLET!

    [SerializeField] private int damageAmount = default;

    private void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamageable>();
        if (damagable != null)
        {
            damagable.Damage(damageAmount);
            gameObject.SetActive(false);
        }
    }

    // Primjer za nullable Vector3
    private void SetTransformPosition(Vector3? newPosition = null)
    {
        newPosition ??= Vector3.zero;
        transform.position = newPosition.Value;
    }
}

public class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField] private Health health;

    public void Damage(int damage)
    {
        health.Damage(damage);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }
}