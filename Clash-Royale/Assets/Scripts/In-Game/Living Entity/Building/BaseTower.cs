using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : LivingEntity, ICanAttack, ICanDamageable
{


    public float AttackSpeed { get ; set ; }
    public float AttackDamage { get ; set ; }
    public LivingEntityTypes[] TypesOfEnemeyToAttack { get ; set; }
    public float AttackRange { get ; set ; }
    public float Health { get; set ; }
    public float MaxHealth { get ; set ; }

    public CharacterStats_SO _characterStats;
    [SerializeField]
    [Utils.ReadOnly]
    private string _characterName;

    private void Awake()
    {
      
        SetPlayerId(_characterStats.DeployTime);
        SetObjectType(_characterStats.LivingEntityType);
        Health = _characterStats.MaxHealth;
        AttackDamage = _characterStats.AttackDamage;
        AttackSpeed = _characterStats.AttackSpeed;
        AttackRange = _characterStats.AttackRange;
        TypesOfEnemeyToAttack = _characterStats.TypesOfEnemeyToAttack;
        _characterName = _characterStats.name;
        MaxHealth = _characterStats.MaxHealth;
    }




    public void AttackTo(ICanDamageable target, float damage)
    {
    }

    public void Deploy()
    {
    }

    public void Die()
    {
       
    }

    public void TakeDamage(float damageAmount)
    {
        if (Health==MaxHealth)// Ask healthbar just for 1 time
        {
        GetHealthBar();

        }
        Health -= damageAmount;
        if (Health <= 0)
        {
            Die();
        }
    
    }
    void GetHealthBar() 
    {
      HealthBar healthBar = ObjectPooler.instance.SpawnFromPool("Ingame_HealthBar", transform.position, Quaternion.identity).GetComponent<HealthBar>();
      healthBar.SetHealthBarData(this.transform);
    }

    public void TakeHeal(float healAmount)
    {
    }
}
