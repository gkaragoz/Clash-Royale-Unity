using UnityEngine;

public class BuildingStats : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private BuildingStats_SO _buildingDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private BuildingStats_SO _building = null;

    #region Initializations

    private void Awake() {
        if (_buildingDefinition_Template != null) {
            _building = Instantiate(_buildingDefinition_Template);
        }
    }

    #endregion

    #region Increasers

    public void IncreaseHealth(float value) {
        if (GetCurrentHealth() + value >= GetMaxHealth()) {
            return;
        }

        _building.CurrentHealth += value;
    }

    public void IncreaseAttackRate(float value) {
        _building.AttackRate -= value;

        if (GetAttackRate() <= GetMaxAttackRate()) {
            _building.AttackRate = GetMaxAttackRate();
        }
    }

    public void IncreaseAttackDamage(float value) {
        _building.AttackDamage += value;
    }

    #endregion

    #region Decreasers

    public void DecreaseHealth(float value) {
        _building.CurrentHealth -= value;

        if (GetCurrentHealth() <= 0) {
            _building.CurrentHealth = 0;
        }
    }

    public void DecreaseAttackRate(float value) {
        _building.AttackRate += value;
    }

    public void DecreaseAttackDamage(float value) {
        _building.AttackDamage -= value;

        if (GetAttackDamage() <= GetMinAttackDamage()) {
            _building.AttackDamage = GetMinAttackDamage();
        }

    }

    #endregion

    #region Setters

    public void SetCurrentHealth(float amount) {
        if (amount <= 0) {
            _building.CurrentHealth = 0;
            return;
        }
        if (amount > GetMaxHealth()) {
            _building.MaxHealth = amount;
        }

        _building.CurrentHealth = amount;
    }

    #endregion

    #region Reporters

    public string GetName() {
        return _buildingDefinition_Template.Name;
    }

    public GameObject GetPrefab() {
        return _buildingDefinition_Template.Prefab;
    }

    public float GetCurrentHealth() {
        return _building.CurrentHealth;
    }

    public float GetMaxHealth() {
        return _building.MaxHealth;
    }

    public float GetAttackRate() {
        return _building.AttackRate;
    }

    public float GetMaxAttackRate() {
        return _building.MaxAttackRate;
    }

    public float GetAttackDamage() {
        return _building.AttackRate;
    }

    public float GetMinAttackDamage() {
        return _building.MinAttackDamage;
    }

    public float GetMovementSpeed() {
        return _building.MovementSpeed;
    }

    public float GetDeployTime() {
        return _building.DeployTime;
    }

    #endregion

    #region Custom Methods
    #endregion

}