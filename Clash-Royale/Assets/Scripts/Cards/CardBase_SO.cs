using UnityEngine;

public enum CardType {
    Troop,
    Spell,
    Building
}

public enum CardRarity {
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Card Stats", menuName = "Scriptable Objects/Cards/Card Stats")]
public class CardBase_SO : ScriptableObject {

    [SerializeField]
    private int _id;
    [SerializeField]
    private CardStringProperty _name;
    [SerializeField]
    private CardStringProperty _description;
    [SerializeField]
    private Arena_SO _arena;
    [SerializeField]
    private CardType _cardType;
    [SerializeField]
    private CardRarity _cardRarity;
    [SerializeField]
    private CardLevel_SO _cardLevel;
    [SerializeField]
    private CardIntProperty _elixirCost;

}
