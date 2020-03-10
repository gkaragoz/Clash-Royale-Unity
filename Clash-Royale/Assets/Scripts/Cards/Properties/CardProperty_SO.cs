using UnityEngine;

[CreateAssetMenu(fileName = "Card Property", menuName = "Scriptable Objects/Cards/Card Property")]
public class CardProperty_SO : ScriptableObject {

    [Header("Initializations")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _iconSprite;

}
