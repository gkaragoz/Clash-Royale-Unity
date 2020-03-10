using UnityEngine;

[System.Serializable]
public class CardFloatProperty {

    [SerializeField]
    private CardProperty_SO _propertySO;
    [SerializeField]
    private float _value;

    public float Value { get => _value; set => _value = value; }
    public CardProperty_SO PropertySO { get => _propertySO; set => _propertySO = value; }
}
