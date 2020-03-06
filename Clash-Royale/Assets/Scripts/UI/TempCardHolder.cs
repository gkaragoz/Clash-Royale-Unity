using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TempCardHolder : MonoBehaviour {

	public enum CardType {
		Poseidon,
		Destroy_Left_Tower,
		Destroy_Right_Tower
	}

	public enum CardAnimType {
		Selectable,
		Consumable
	}

	[Header("Initializations")]
	public CardType cardType;
	public CardAnimType cardAnimType;
	public UnityEvent onClickEvent;

	[Header("Debug")]
	[SerializeField]
	[Utils.ReadOnly]
	private Button _thisButton;

	private void Awake() {
		_thisButton = GetComponent<Button>();

		_thisButton.onClick.AddListener(delegate { onClickEvent?.Invoke(); });
	}

	public void Select() {
		if (cardAnimType == CardAnimType.Selectable) {
			LeanTween.moveY(this.gameObject, transform.position.y + 50, .5f).setEaseOutCubic();
			LeanTween.scale(this.gameObject, transform.localScale * 1.2f, .5f).setEaseOutCubic();
		} else {
			_thisButton.interactable = false;
		}
	}

	public void Deselect() {
		if (cardAnimType == CardAnimType.Selectable) {
			LeanTween.moveY(this.gameObject, transform.position.y - 50, .5f).setEaseOutQuart();
			LeanTween.scale(this.gameObject, transform.localScale / 1.2f, .5f).setEaseOutQuart();
		}
	}

}
