using UnityEngine;

public class Center : LivingEntity, ICanDamageable
{
    HealthBar healthBar;
    bool haveHealthBar;
    public CharacterStats_SO _characterStats;

    public float Health { get ; set ; }
    private float _maxHealth;

    private void Awake()
    {
        SetPlayerId(_characterStats.DeployTime);
        SetObjectType(_characterStats.LivingEntityType);
        Health = _characterStats.MaxHealth;
        _maxHealth = Health;
    }
   


    public void Deploy()
    {
    }

    public void Die()
    {
        TargetManager.instance.RemoveTarget(this);
        Debug.Log(name + " is Died");
        transform.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Die();
        }
        GetHealthBar();
    }
    void GetHealthBar()
    {
        if (!haveHealthBar)
        {
            healthBar = ObjectPooler.instance.SpawnFromPool("Ingame_HealthBar", transform.position, Quaternion.identity).GetComponent<HealthBar>();

            healthBar.SetHealthBarData(transform, GameObject.Find("Canvas").GetComponent<RectTransform>());
            healthBar.gameObject.transform.SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>());
            healthBar.OnHealthChanged(Health / _characterStats.MaxHealth);
            healthBar.gameObject.SetActive(true);
            haveHealthBar = true;
        }
        else
        {
            healthBar.OnHealthChanged(Health / _characterStats.MaxHealth);

        }


    }

    public void TakeHeal(float healAmount)
    {
    }
}
