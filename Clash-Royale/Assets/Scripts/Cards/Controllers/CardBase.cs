using System;
using UnityEngine;

public class CardBase : MonoBehaviour {

    public Action OnIdChanged;
    public Action OnNameChanged;
    public Action OnDescriptionChanged;
    public Action OnArenaChanged;
    public Action OnCardTypeChanged;
    public Action OnCardRarityChanged;
    public Action OnCardUpgradeableChanged;
    public Action OnElixirCostChanged;
    public Action OnCardLevelChanged;

    [Header("Initialization")]
    [SerializeField]
    private CardBase_SO _cardBaseDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CardBase_SO _cardBase = null;


    #region Initializations

    private void Awake() {
        if (_cardBaseDefinition_Template != null) {
            _cardBase = Instantiate(_cardBaseDefinition_Template);
        }
    }

    #endregion

    #region Setters
    public void SetId(int id) {
        _cardBase.Id = id;

        OnIdChanged?.Invoke();
    }

    public void SetName(CardStringProperty name) {
        _cardBase.Name = name;

        OnNameChanged?.Invoke();
    }

    public void SetDescription(CardStringProperty description) {
        _cardBase.Description = description;

        OnDescriptionChanged?.Invoke();
    }

    public void SetArena(CardArena arena) {
        _cardBase.Arena = arena;

        OnArenaChanged?.Invoke();
    }

    public void SetCardType(CardType type) {
        _cardBase.CardType = type;

        OnCardTypeChanged?.Invoke();
    }

    public void SetCardRarity(CardRarity rarity) {
        _cardBase.CardRarity = rarity;

        OnCardRarityChanged?.Invoke();
    }

    public void SetCardUpgradeable(CardUpgradeable_SO upgradeable) {
        _cardBase.CardUpgradeable = upgradeable;

        OnCardUpgradeableChanged?.Invoke();
    }

    public void SetElixirCost(CardIntProperty cost) {
        _cardBase.ElixirCost = cost;

        OnElixirCostChanged?.Invoke();
    }

    public void SetCardLevel(CardIntProperty level) {
        _cardBase.CardLevel = level;

        OnCardLevelChanged?.Invoke();
    }
    #endregion

    #region Reporters

    public int GetId() {
        return _cardBase.Id;
    }

    public string GetName() {
        return _cardBase.Name.Value;
    }

    public string GetDescription() {
        return _cardBase.Description.Value;
    }

    public CardArena GetArena() {
        return _cardBase.Arena;
    }

    public CardType GetCardType() {
        return _cardBase.CardType;
    }

    public CardRarity GetCardRarity() {
        return _cardBase.CardRarity;
    }

    public CardUpgradeable_SO GetCardUpgradeable() {
        return _cardBase.CardUpgradeable;
    }

    public int GetElixirCost() {
        return _cardBase.ElixirCost.Value;
    }

    public int GetCardLevel() {
        return _cardBase.CardLevel.Value;
    }

    #endregion

    #region Custom Methods

    #endregion

}