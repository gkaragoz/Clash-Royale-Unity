using TMPro;
using UnityEngine;

public class UICardView : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Color _commonColor = Color.black;
    [SerializeField]
    private Color _rareColor = Color.black;
    [SerializeField]
    private Color _epicColor = Color.black;
    [SerializeField]
    private Color _LegendaryColor = Color.black;

    [SerializeField]
    private TextMeshProUGUI _txtId = null;
    [SerializeField]
    private TextMeshProUGUI _txtName = null;
    [SerializeField]
    private TextMeshProUGUI _txtDescription = null;
    [SerializeField]
    private TextMeshProUGUI _txtArena = null;
    [SerializeField]
    private TextMeshProUGUI _txtCardType = null;
    [SerializeField]
    private TextMeshProUGUI _txtCardRarity = null;
    [SerializeField]
    private TextMeshProUGUI _txtElixirCost = null;
    [SerializeField]
    private TextMeshProUGUI _txtUpgradeCost = null;
    [SerializeField]
    private TextMeshProUGUI _txtCardLevel = null;
    [SerializeField]
    private TextMeshProUGUI _txtMaxLevel = null;
    [SerializeField]
    private TextMeshProUGUI _txtRequiredCardsToLevelUp = null;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private CardBase _cardBase;

    private void Awake() {
        _cardBase = GetComponent<CardBase>();

        _cardBase.OnIdChanged += OnIdChanged;
        _cardBase.OnNameChanged += OnNameChanged;
        _cardBase.OnDescriptionChanged += OnDescriptionChanged;
        _cardBase.OnArenaChanged += OnArenaChanged;
        _cardBase.OnCardTypeChanged += OnCardTypeChanged;
        _cardBase.OnCardRarityChanged += OnCardRarityChanged;
        _cardBase.OnCardUpgradeableChanged += OnCardLevelChanged;
        _cardBase.OnElixirCostChanged += OnElixirCostChanged;
    }

    private void Start() {
        Init();
    }

    private void Init() {
        OnIdChanged();
        OnNameChanged();
        OnDescriptionChanged();
        OnArenaChanged();
        OnCardTypeChanged();
        OnCardRarityChanged();
        OnCardLevelChanged();
        OnElixirCostChanged();
    }

    private void OnIdChanged() {
        _txtId.text = "ID:\t" + _cardBase.GetId();
    }

    private void OnNameChanged() {
        _txtName.text = "Name:\t" + _cardBase.GetName();
    }

    private void OnDescriptionChanged() {
        _txtDescription.text = "Description:\t" + _cardBase.GetDescription();
    }

    private void OnArenaChanged() {
        _txtArena.text = "Arena:\t" + _cardBase.GetArena().GetArenaName();
    }

    private void OnCardTypeChanged() {
        _txtCardType.text = "Card Type:\t" + _cardBase.GetCardType();
    }

    private void OnCardRarityChanged() {
        CardRarity rarity = _cardBase.GetCardRarity();
        string finalText = "Card Rarity:\t";

        switch (rarity) {
            case CardRarity.Common:
                finalText += "<color #" + ColorUtility.ToHtmlStringRGB(_commonColor) + ">" + rarity.ToString();
                break;
            case CardRarity.Rare:
                finalText += "<color #" + ColorUtility.ToHtmlStringRGB(_rareColor) + ">" + rarity.ToString();
                break;
            case CardRarity.Epic:
                finalText += "<color #" + ColorUtility.ToHtmlStringRGB(_epicColor) + ">" + rarity.ToString();
                break;
            case CardRarity.Legendary:
                finalText += "<color #" + ColorUtility.ToHtmlStringRGB(_LegendaryColor) + ">" + rarity.ToString();
                break;
        }

        _txtCardRarity.text = finalText;
    }

    private void OnCardLevelChanged() {
        CardUpgradeable_SO cardUpgradeable = _cardBase.GetCardUpgradeable();
        int cardLevel = _cardBase.GetCardLevel();
        _txtUpgradeCost.text = "Upgrade Cost:" + cardUpgradeable.GetUpgradeCost(cardLevel);
        _txtCardLevel.text = "Card Level:" + cardLevel;
        _txtMaxLevel.text = "Card Max Level:" + cardUpgradeable.MaxLevel;
        _txtRequiredCardsToLevelUp.text = "Required Cards To Level Up:" + cardUpgradeable.GetRequiredCards(cardLevel);

    }

    private void OnElixirCostChanged() {
        _txtElixirCost.text = "Elixir Cost:" + _cardBase.GetElixirCost();
    }
}
