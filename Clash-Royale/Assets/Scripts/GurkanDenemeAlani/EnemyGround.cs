using Pathfinding;
using System;
using UnityEngine;

public class EnemyGround : StandardChars
{


    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private CharacterMotor _characterMotor;
    [SerializeField]
    [Utils.ReadOnly]
    private CharacterPathfinder _characterPathfinder;


    void Awake()
    {

        _characterMotor = GetComponent<CharacterMotor>();
        _characterPathfinder = GetComponent<CharacterPathfinder>();

        Health = 50;
        CharacterType = LivingEntityTypes.DynamicGround;
    }

    private void Start()
    {
        Debug.Log(Health);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        Health -= amount;
        Debug.Log(transform.name + " Health: " + Health);
        if (Health <= 0)
        {
            Debug.Log("Died");
            Die();
        }
    }


    public override void Die()
    {
        base.Die();
        transform.gameObject.SetActive(false);
        GameManager.instance.myTargetList.Remove(transform);
    }

}
