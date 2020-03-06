using UnityEngine;

public class TempCardController : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private UIGridSnap _UIGridSnap = null;
    [SerializeField]
    private UITerritoryDraw _UITerritoryDraw = null;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private TempCardHolder _selectedCardHolder = null;
    
    public void UseCard(TempCardHolder cardHolder) {
        if (_selectedCardHolder == cardHolder) {
            _selectedCardHolder.Deselect();
            _selectedCardHolder = null;

            _UIGridSnap.CardReleaseMode = false;
        } else {

            if (_selectedCardHolder != null) {
                _selectedCardHolder.Deselect();
            }

            _selectedCardHolder = cardHolder;
            _selectedCardHolder.Select();
            
            if (_selectedCardHolder.cardAnimType == TempCardHolder.CardAnimType.Selectable) {
                _UIGridSnap.CardReleaseMode = true;
            }
        }

        switch (cardHolder.cardType) {
            case TempCardHolder.CardType.Poseidon:
                Debug.Log("Poseidon");
                break;
            case TempCardHolder.CardType.Destroy_Left_Tower:
                _UIGridSnap.DestroyTower(0);
                _UITerritoryDraw.DestroyTerritory(0);
                break;
            case TempCardHolder.CardType.Destroy_Right_Tower:
                _UIGridSnap.DestroyTower(1);
                _UITerritoryDraw.DestroyTerritory(1);
                break;
        }
    }

}
