using UnityEngine;

public class CardProperty : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private CardProperty_SO _cardPropertyDefinition_Template = null;

    [Header("Debug")]
    [SerializeField]
    private CardProperty_SO _cardProperty = null;

    #region Initializations

    private void Awake() {
        if (_cardPropertyDefinition_Template != null) {
            _cardProperty = Instantiate(_cardPropertyDefinition_Template);
        }
    }

    #endregion

    #region Setters
    public void SetName(string name) {
        _cardProperty.Name = name;
    }

    public void SetIconSprite(Sprite icon) {
        _cardProperty.IconSprite = icon;
    }

    #endregion

    #region Reporters

    public string GetName() {
        return _cardProperty.Name;
    }

    public Sprite GetIconSprite() {
        return _cardProperty.IconSprite;
    }

    #endregion

    #region Custom Methods

    #endregion

}