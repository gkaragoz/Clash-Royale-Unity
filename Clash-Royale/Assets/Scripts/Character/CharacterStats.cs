using UnityEngine;

public class CharacterStats : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private CharacterStats_SO _characterDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CharacterStats_SO _character = null;

    #region Initializations

    private void Awake() {
        if (_characterDefinition_Template != null) {
            _character = Instantiate(_characterDefinition_Template);
        }
    }

    #endregion

    #region Increasers

    public void IncreaseHealth(float value) {
        if (GetCurrentHealth() + value >= GetMaxHealth()) {
            return;
        }

        _character.CurrentHealth += value;
    }

    public void IncreaseAttackRate(float value) {
        _character.AttackRate -= value;

        if (GetAttackRate() <= GetMaxAttackRate()) {
            _character.AttackRate = GetMaxAttackRate();
        }
    }

    public void IncreaseAttackDamage(float value) {
        _character.AttackDamage += value;
    }

    #endregion

    #region Decreasers

    public void DecreaseHealth(float value) {
        _character.CurrentHealth -= value;

        if (GetCurrentHealth() <= 0) {
            _character.CurrentHealth = 0;
        }
    }

    public void DecreaseAttackRate(float value) {
        _character.AttackRate += value;
    }

    public void DecreaseAttackDamage(float value) {
        _character.AttackDamage -= value;

        if (GetAttackDamage() <= GetMinAttackDamage()) {
            _character.AttackDamage = GetMinAttackDamage();
        }

    }

    #endregion

    #region Setters

    public void SetCurrentHealth(float amount) {
        if (amount <= 0) {
            _character.CurrentHealth = 0;
            return;
        }
        if (amount > GetMaxHealth()) {
            _character.MaxHealth = amount;
        }

        _character.CurrentHealth = amount;
    }

    #endregion

    #region Reporters

    public string GetName() {
        return _characterDefinition_Template.Name;
    }

    public GameObject GetPrefab() {
        return _characterDefinition_Template.Prefab;
    }

    public float GetCurrentHealth() {
        return _character.CurrentHealth;
    }

    public float GetMaxHealth() {
        return _character.MaxHealth;
    }

    public float GetAttackRate() {
        return _character.AttackRate;
    }

    public float GetMaxAttackRate() {
        return _character.MaxAttackRate;
    }

    public float GetAttackDamage() {
        return _character.AttackRate;
    }

    public float GetMinAttackDamage() {
        return _character.MinAttackDamage;
    }

    public float GetMovementSpeed() {
        return _character.MovementSpeed;
    }
    public float GetInitDelay() {
        return _character.InitDelay;
    }

    #endregion

    #region Custom Methods
    #endregion

}