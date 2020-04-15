
public interface ICanDamageable
{
    float Health { get; set; }
    float MaxHealth { get; set; }

    void TakeDamage(float damageAmount);

    void TakeHeal(float healAmount);

    void Deploy();

    void Die();

}
