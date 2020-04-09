public interface ICanAttack
{
    float AttackSpeed { get; set; }
    float AttackDamage { get; set; }
    LivingEntityTypes[] TypesOfEnemeyToAttack { get; set; }
    float AttackRange { get; set; }

    void AttackTo(ICanDamageable target,float damage);


}
