using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Factory_Method
{
    public class FactoryMainScript : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GridLayoutGroup _gridLayout;

        [Header("Buttons")] 
        [SerializeField] private Button _redMageButton;
        [SerializeField] private Button _blueMageButton;

        [Header("Units Prefabs")] 
        [SerializeField] private Mage _redMage;
        [SerializeField] private Mage _blueMage;

        private void OnEnable()
        {
            _redMageButton.onClick.AddListener(() => CreateMage(new RedCreator(_redMage)));
            _blueMageButton.onClick.AddListener(() => CreateMage(new BlueCreator(_blueMage)));
        }

        private void OnDisable()
        {
            _redMageButton.onClick.RemoveAllListeners();
            _blueMageButton.onClick.RemoveAllListeners();
        }

        private void CreateMage(Creator creator)
        {
            Mage mage = creator.FactoryMethod();
            mage.Cast();
            mage.transform.SetParent(_gridLayout.transform, false);
        }
    }
}
