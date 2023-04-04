using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private float knockback;
    private int damage;

    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);
 
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);//right here!
        }

        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        SetAttack(damage, knockback, 15);// always 15 needs to feed in stat then remove this method
        // damage and knockback should also be in stat not statemachine
    }

    public void SetAttack(int damage, float knockback, int strength)
    {
        //this.damage = damage;
        this.knockback = knockback;
        Debug.Log(damage + " * (1 + (" + strength + " / 100))");
        this.damage = damage * (1 + (strength / 100));
        Debug.Log("new damage " + this.damage);
    }
}
