using UnityEngine;

[CreateAssetMenu(fileName = "Card Property", menuName = "Scriptable Objects/Cards/Card Property")]
public class CardProperty_SO : ScriptableObject {

    [Header("Initializations")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _iconSprite;

    public string Name { get => _name; set => _name = value; }
    public Sprite IconSprite { get => _iconSprite; set => _iconSprite = value; }
}
