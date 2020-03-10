using UnityEngine;

public class CardLevel : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private CardLevel_SO _cardLevelDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CardLevel_SO _cardLevelProperty = null;

    #region Initializations

    private void Awake() {
        if (_cardLevelDefinition_Template != null) {
            _cardLevelProperty = Instantiate(_cardLevelDefinition_Template);
        }
    }

    #endregion

    #region Setters
    
    public void SetBaseLevel(int baseLevel) {
        _cardLevelProperty.BaseLevel = baseLevel;
    }

    public void SetMaxLevel(int maxLevel) {
        _cardLevelProperty.MaxLevel = maxLevel;
    }

    public void SetCurrentLevel(int currentLevel) {
        _cardLevelProperty.CurrentLevel = currentLevel;
    }

    public void SetLevelUp(LevelUp[] levels) {
        _cardLevelProperty.Levels = levels;
    }

    #endregion

    #region Reporters

    public int GetBaseLevel() {
        return _cardLevelProperty.BaseLevel;
    }

    public int GetMaxLevel() {
        return _cardLevelProperty.MaxLevel;
    }

    public int GetCurrentLevel() {
        return _cardLevelProperty.CurrentLevel;
    }

    public LevelUp[] GetLevelUp() {
        return _cardLevelProperty.Levels;
    }

    #endregion

    #region Custom Methods

    #endregion

}