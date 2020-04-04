using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterPathfinder))]
public class Pose : StandardChars,ICanAttack
{    
    public bool canAttack;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private MotorPose _characterMotor;
    [SerializeField]
    [Utils.ReadOnly]
    private CharacterPathfinder _characterPathfinder;

    public float AttackSpeed { get ; set; }
    public float AttackDamage { get ; set; }
    public LivingEntityTypes[] TypesOfAttackTargets { get ; set ; }
    public float AttackRange { get; set; }

    void Awake()
    {
        _characterMotor = GetComponent<MotorPose>();
        _characterPathfinder = GetComponent<CharacterPathfinder>();
    }



    private void Start()
    {

        Health = 100;
        CharacterType = LivingEntityTypes.DynamicGround;
        TypesOfAttackTargets = new LivingEntityTypes[]{LivingEntityTypes.DynamicGround, LivingEntityTypes.Static };
        AttackRange = 5f;
        AttackDamage = 10f;
        AttackSpeed = 2f;
    }


    private void Update()
    {
        if (_characterPathfinder.currentEnemy != null)//Hedefimde enemy var ise
        {
            MoveAndAttackToEnemy();

        }
        else //Hedef ölüyse ya da tamamen görüş dışı ise
        {
            canAttack = false;
            _characterMotor.StartMovement();
        }

        
    }

    public void MoveAndAttackToEnemy()
    {
        if (Vector3.Distance(transform.position, _characterPathfinder.currentEnemy.position) < AttackRange)
        {
            _characterMotor.StopMovement();
            StartAttack(_characterPathfinder.currentEnemy.GetComponent<StandardChars>());
        }
        else //enemy Hedefimde ama Range içinde değil ise
        {
            canAttack = false;
            _characterMotor.StartMovement();

        }
    }

    public void StartAttack(StandardChars target)
    {
        if (canAttack == false)
        {
            canAttack = true;
            StartCoroutine(AttackToEnemy(target));
        }
    }
  
    IEnumerator AttackToEnemy(StandardChars target)
    {
        while (canAttack)
        {           
            yield return new WaitForSeconds(AttackSpeed);
            target.TakeDamage(AttackDamage);
  
        }
    }
    
    

}
