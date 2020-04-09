
public interface ICanDamageable
{
    float Health { get; set; }
    void TakeDamage(float damageAmount);

    void TakeHeal(float healAmount);

    void Deploy();

    void Die();

}
