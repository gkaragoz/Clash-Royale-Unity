using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "Scriptable Objects/Character Stats")]
public class CharacterStats_SO : ScriptableObject {

    #region Properties

    [SerializeField]
    private string _name = "Character";
    [SerializeField]
    private LivingEntityTypes _livingEntityType;  
    [SerializeField]
    private LivingEntityTypes[] _TypesOfEnemyToAttack;
    [SerializeField]
    private GameObject _prefab;

    // Health
    [SerializeField]
    private float _maxHealth;

    // Attack
    [SerializeField]
    private float _attackSpeed = 1f;
    [SerializeField]
    private float _attackDamage = 50f;
    [SerializeField]
    private float _attackRange = 1f;
    [SerializeField]
    private float _enemyDedectionRange = 4f;

    // Movement
    [SerializeField]
    private float _movementSpeed = 5f;


    // Wait Time Before Moving
    [SerializeField]
    private float _deployTime = 1f;
         
    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public LivingEntityTypes LivingEntityType
    {
        get { return _livingEntityType; }
        set { _livingEntityType = value; }
    }
    public GameObject Prefab {
        get { return _prefab; }
        set { _prefab = value; }
    }

    public LivingEntityTypes[] TypesOfEnemeyToAttack
    {
        get { return _TypesOfEnemyToAttack; }
        set {  _TypesOfEnemyToAttack = value; }
    }

   
    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public float AttackRange {
        get { return _attackRange; }
        set { _attackRange = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }
    public float AttackDamage {
        get { return _attackDamage; }
        set { _attackDamage = value; }
    }

    public float EnemyDedectionRange {
        get { return _enemyDedectionRange; }
    }

    public float DeployTime {
        get { return _deployTime; }
        set { _deployTime = value; }
    }

    public float MovementSpeed {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    #endregion

}