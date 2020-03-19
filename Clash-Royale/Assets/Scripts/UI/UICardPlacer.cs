using System;
using System.Collections;
using UnityEngine;

namespace Ganover.InGame.UI {

    public class UICardPlacer : MonoBehaviour {

        // TODO 
        // Create another class to handle these Actions.
        //public Action<CardID> OnCardSelected;
        //public Action<CardID> OnCardDeselected;
        //public Action<CardID> OnCardReleased;

        [Header("Debug")]
        [SerializeField]
        private LivingEntityTypes _selectedType = LivingEntityTypes.None;

        private Coroutine _selectorCoroutine;
        private GameObject _cardPrefab;
        private GameObject _selectedCard;

        private void SelectCard() {
            _selectorCoroutine = StartCoroutine(ISelectCard());
        }

        public bool HasCard {
            get {
                return _selectorCoroutine == null ? true : false;
            }
        }

        private IEnumerator ISelectCard() {
            Debug.Log("Select card and start coroutine for " + this._selectedType);
            _selectedCard = Instantiate(_cardPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

            while (true) {
                _selectedCard.transform.position = GetNodePosition();

                if (Input.GetMouseButtonDown(0)) {
                    Deploy();
                    break;
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private void DeselectCard() {
            Debug.Log("Deselect card and stop coroutine for " + this._selectedType);

            StopCoroutine(_selectorCoroutine);
            _selectorCoroutine = null;

            Destroy(_selectedCard);
            _cardPrefab = null;
            _selectedType = LivingEntityTypes.None;
        }

        private void Deploy() {
            switch (_selectedType) {
                case LivingEntityTypes.None:
                    break;
                case LivingEntityTypes.DynamicFly:
                    break;
                case LivingEntityTypes.DynamicGround:
                    break;
                case LivingEntityTypes.Static:
                    break;
            }
        }

        private Vector2 GetNodePosition() {
            return Vector2.zero;
        }

        private void SwitchCard(UICard newCard) {
            Debug.Log("Switching card between " + this._selectedCard.name + " and " + newCard.CardPrefab.name);
            
            if (this._selectedType == newCard.Type) {

                DeselectCard();
                return;
            } else {
                DeselectCard();

                this._selectedType = newCard.Type;
                this._cardPrefab = newCard.CardPrefab;

                SelectCard();
            }
        }

        public void SelectType(UICard uiCard) {
            Debug.Log("Selected type: " + uiCard.Type);

            if (HasCard) {
                Debug.Log("First time selected. ");

                this._selectedType = uiCard.Type;
                this._cardPrefab = uiCard.CardPrefab;

                SelectCard();
            } else {
                SwitchCard(uiCard);
            }
        }

    }

}