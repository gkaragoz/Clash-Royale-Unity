using Pathfinding;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterStats), typeof(CharacterMotor), typeof(CharacterPathfinder))]
public abstract class Character : LivingEntity {

    public Action OnCharacterDeployed;
    public Action OnCharacterDead;

    [Header("Initializations")]
    [SerializeField]
    private CharacterStats _characterStats;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private CharacterMotor _characterMotor;
    [SerializeField]
    [Utils.ReadOnly]
    private CharacterPathfinder _characterPathfinder;

    public Transform CurrentTargetTransform {
        get {
            return _characterPathfinder.CurrentTarget; //////////////////
        }
    }

    public override void Awake() {
        base.Awake();

        _characterMotor = GetComponent<CharacterMotor>();
        _characterPathfinder = GetComponent<CharacterPathfinder>();

        _characterPathfinder.OnPathFound += OnPathFound;
        _characterMotor.OnTargetReached += OnTargetReached;
    }

    private void OnPathFound(Path path) {
        _characterMotor.SetPath(path);
        _characterMotor.StartMovement();
    }

    private void OnTargetReached() {
        _characterPathfinder.StopSearch();
        _characterMotor.StopMovement();

        //////////////////_characterPathfinder.RemoveTarget(CurrentTargetTransform);

        _characterPathfinder.StartSearch();
    }

    public override void OnObjectReused() {
        base.OnObjectReused();

        Deploy();
    }

    public override void Deploy() {
        base.Deploy();

        this.gameObject.SetActive(true);

        for (int ii = 0; ii < GameManager.instance.targets.Length; ii++) {
            //////////////////_characterPathfinder.AddTarget(GameManager.instance.targets[ii]);
        }

        _characterPathfinder.StartSearch();

        OnCharacterDeployed?.Invoke();
    }

    public override void Die() {
        base.Die();

        OnCharacterDead?.Invoke();
    }

}
