using UnityEngine;

namespace Ganover.InGame.UI {

    public class UICard : MonoBehaviour {

        [Header("Initializations")]
        [SerializeField]
        private LivingEntityTypes _type = LivingEntityTypes.None;
        [SerializeField]
        private GameObject _cardPrefab = null;

        public LivingEntityTypes Type {
            get {
                return _type;
            }
        }

        public GameObject CardPrefab {
            get {
                return _cardPrefab;
            }
        }

    }

}