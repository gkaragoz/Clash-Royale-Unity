using UnityEngine;

[System.Serializable]
public class CardIntProperty {

    [SerializeField]
    private CardProperty_SO _propertySO;
    [SerializeField]
    private int _value;

    public int Value { get => _value; set => _value = value; }
    public CardProperty_SO PropertySO { get => _propertySO; set => _propertySO = value; }

}
