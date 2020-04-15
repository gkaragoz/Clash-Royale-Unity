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

        public bool IsEmpty {
            get {
                return _selectorCoroutine == null ? true : false;
            }
        }

        private IEnumerator ISelectCard() {
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
                    GameObject goDynamic=ObjectPooler.instance.SpawnFromPool("Ingame_Poseidon", GetNodePosition(), Quaternion.identity);
                    goDynamic.SetActive(true);
                    break;
                case LivingEntityTypes.Static:
                    GameObject goStatic = ObjectPooler.instance.SpawnFromPool("Ingame_StaticBuilding", GetNodePosition(), Quaternion.identity);
                    break;
            }
            
            DeselectCard();
            AstarPath.active.Scan();
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
            if (IsEmpty) {
                this._selectedType = uiCard.Type;
                this._cardPrefab = uiCard.CardPrefab;

                SelectCard();
            } else {
                SwitchCard(uiCard);
            }
        }

    }

}