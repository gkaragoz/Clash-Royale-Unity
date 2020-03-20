using Pathfinding;
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
            _selectedCard = Instantiate(_cardPrefab);

            while (true) {
                _selectedCard.transform.position = GetNodePosition();

                if (Input.GetMouseButtonDown(0)) {
                    Deploy();
                    break;
                }

                yield return null;
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
                    GameObject lastCard2 = Instantiate(_selectedCard, GetNodePosition(), Quaternion.identity);
                    lastCard2.transform.GetChild(1).gameObject.SetActive(true);
                    lastCard2.transform.GetChild(0).gameObject.SetActive(false);
                    lastCard2.transform.GetChild(4).gameObject.SetActive(true);

                    AstarPath.active.Scan();
                    DeselectCard();
                    break;
                case LivingEntityTypes.DynamicGround:
                    GameObject obj = ObjectPooler.instance.SpawnFromPool("Ingame_Poseidon", GetNodePosition(), Quaternion.identity);
                    Destroy(_selectedCard);
                    AstarPath.active.Scan();
                    DeselectCard();
                    break;
                case LivingEntityTypes.Static:
                    GameObject obje1 = ObjectPooler.instance.SpawnFromPool("Ingame_StaticBuilding", GetNodePosition(), Quaternion.identity);
                    obje1.transform.GetChild(1).gameObject.SetActive(true);
                    obje1.transform.GetChild(0).gameObject.SetActive(false);
                    obje1.transform.GetChild(4).gameObject.SetActive(true);
                    Destroy(_selectedCard);
                    AstarPath.active.Scan();
                    DeselectCard();
                    break;
            }
        }

        private Vector2 GetNodePosition() {


            NNConstraint constraint = NNConstraint.None;
            constraint.constrainWalkability = true;
            constraint.walkable = true;
            constraint.graphMask = 1 << 1;
            GraphNode gg = AstarPath.active.GetNearest(Camera.main.ScreenToWorldPoint(Input.mousePosition), constraint).node;

            return (Vector3)gg.position;
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