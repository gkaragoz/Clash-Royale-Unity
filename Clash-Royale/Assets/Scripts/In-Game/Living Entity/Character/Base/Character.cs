using Pathfinding;
using System;
using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(CharacterMotor), typeof(Seeker), typeof(CharacterPathfinder))]
public class Character : LivingEntity, ICanDamageable, ICanMove, ICanAttack, IPooledObject
{
    HealthBar healthBar;
    bool haveHealthBar;
    bool canAttack;
    public CharacterPathfinder _characterPathfinder;
    public CharacterMotor _characterMotor;
    public CharacterStats_SO _characterStats;

    [SerializeField]
    [Utils.ReadOnly]
    private string _characterName;
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public float MovementSpeed { get; set; }

    public float AttackSpeed { get; set; }
    public float AttackDamage { get; set; }
    public LivingEntityTypes[] TypesOfEnemeyToAttack { get; set; }
    public float AttackRange { get; set; }



    #region Initialization 
    private void Awake()
    {
        _characterMotor = GetComponent<CharacterMotor>();
        _characterPathfinder = GetComponent<CharacterPathfinder>();
        SetPlayerId(_characterStats.DeployTime);
        SetObjectType(_characterStats.LivingEntityType);
        Health = _characterStats.MaxHealth;
        MovementSpeed = _characterStats.MovementSpeed;
        AttackDamage = _characterStats.AttackDamage;
        AttackSpeed = _characterStats.AttackSpeed;
        AttackRange = _characterStats.AttackRange;
        TypesOfEnemeyToAttack = _characterStats.TypesOfEnemeyToAttack;
        _characterName = _characterStats.name;
        MaxHealth = _characterStats.MaxHealth; 
    }



    #endregion

    public void Deploy()
    {
        Debug.Log(_characterName + " is Deployed!");

    }

    public void Die()
    {
        TargetManager.instance.RemoveTarget(this);
        Debug.Log(name + " is Died");
        transform.gameObject.SetActive(false);
    }

    public void OnObjectReused()
    {
    }

    public void TakeDamage(float damageAmount)
    {
        if (Health == MaxHealth)// Ask healthbar just for 1 time
        {
            GetHealthBar();

        }

        Health -= damageAmount;
        if (Health <= 0)
        {
            Die();
        }
        ObjectPooler.instance.SpawnFromPool("Ingame_HealthBar", transform.position, Quaternion.identity);
    }

    void GetHealthBar()
    {
        HealthBar healthBar = ObjectPooler.instance.SpawnFromPool("Ingame_HealthBar", transform.position, Quaternion.identity).GetComponent<HealthBar>();
        healthBar.SetHealthBarData(this.transform);
    }

    public void TakeHeal(float healAmount)
    {
        Health += healAmount;
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }

    }

    public virtual void AttackTo(ICanDamageable target, float damage)
    {
        target.TakeDamage(damage);
    }


    public void CalculatePointsAroundObject(AIBase[] agents, Transform targetTransform, float positionRadius)
    {
        float subAngle = 360f / agents.Length;
        float currentAngle = 0;

        Vector3 currentPos = targetTransform.position;

        for (int i = 0; i < agents.Length; i++)
        {
            agents[i].destination = new Vector3(
                Mathf.Sin(Mathf.Deg2Rad * currentAngle) * positionRadius + currentPos.x,
                currentPos.y,
                Mathf.Cos(Mathf.Deg2Rad * currentAngle) * positionRadius + currentPos.z);

            currentAngle += subAngle;
        }
    }



}
