using UnityEngine;

public class Tower : LivingEntity, ICanDamageable
{
   
    public CharacterStats_SO _characterStats;

    public float Health { get ; set ; }
    public float MaxHealth { get ; set ; }

   

    private void Awake()
    {
        SetPlayerId(_characterStats.DeployTime);
        SetObjectType(_characterStats.LivingEntityType);
        Health = _characterStats.MaxHealth;
        MaxHealth = Health;
    }
   


    public void Deploy()
    {
    }

    public void Die()
    {
        TargetManager.instance.RemoveTarget(this);
        Debug.Log(name + " is Died");
        transform.gameObject.SetActive(false);

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

