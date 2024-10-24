using UnityEngine;
using UnityEngine.UI;

namespace AbstractFactory
{
    public class AbstarctFactoryMainScript : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GridLayoutGroup _gridLayout;
        
        [Header("Buttons")]
        [SerializeField] private Button _knightButton;
        [SerializeField] private Button _archerButton;
        [SerializeField] private Button _mageButton;

        [Header("Toggles")]
        [SerializeField] private Toggle _redToggle;
        [SerializeField] private Toggle _blueToggle;

        [Header("Red Units")]
        [SerializeField] private Knight _redKnight;
        [SerializeField] private Archer _redArcher;
        [SerializeField] private Mage _redMage;

        [Header("Blue Units")]
        [SerializeField] private Knight _blueKnight;
        [SerializeField] private Archer _blueArcher;
        [SerializeField] private Mage _blueMage;

        private UnitsFactory _currentFactory;

        private void Awake()
        {
            _currentFactory = new RedFactory();
            _currentFactory.Init(_redKnight, _redArcher, _redMage);
        }

        private void OnEnable()
        {
            SubscribeButtons();
            SubscribeToggles();
        }

        private void OnDisable()
        {
            UnsubscribeButtons();
            UnsubscribeToggles();
        }

        private void SubscribeButtons()
        {
            _knightButton.onClick.AddListener(CreateKnight);
            _archerButton.onClick.AddListener(CreateArcher);
            _mageButton.onClick.AddListener(CreateMage);
        }

        private void UnsubscribeButtons()
        {
            _knightButton.onClick.RemoveListener(CreateKnight);
            _archerButton.onClick.RemoveListener(CreateArcher);
            _mageButton.onClick.RemoveListener(CreateMage);
        }

        private void SubscribeToggles()
        {
            _redToggle.onValueChanged.AddListener((value) =>
            {
                if (value)
                {
                    _currentFactory = new RedFactory();
                    _currentFactory.Init(_redKnight, _redArcher, _redMage);
                }
            });

            _blueToggle.onValueChanged.AddListener((value) =>
            {
                _currentFactory = new BlueFactory();
                _currentFactory.Init(_blueKnight, _blueArcher, _blueMage);
            });
        }

        private void UnsubscribeToggles()
        {
            _redToggle.onValueChanged.RemoveAllListeners();
            _blueToggle.onValueChanged.RemoveAllListeners();
        }

        private void CreateKnight()
        {
            var knight = _currentFactory.CreateKnight();
            knight.transform.SetParent(_gridLayout.transform, false);
        }

        private void CreateArcher()
        {
            var archer = _currentFactory.CreateArcher();
            archer.transform.SetParent(_gridLayout.transform, false);
        }

        private void CreateMage()
        {
            var mage = _currentFactory.CreateMage();
            mage.transform.SetParent(_gridLayout.transform, false);
        }
    }
}