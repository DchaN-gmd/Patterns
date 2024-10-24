using UnityEngine;
using UnityEngine.UI;

namespace Decorator
{
    public class DecoratorLevel : MonoBehaviour
    {
        [Header(("Parameters"))]
        [SerializeField] [Min(0)] private int _damage;
        [SerializeField] [Min(0)] private int _healthValue;

        [Header("References")]
        [SerializeField] private Button _takeDamageButton;

        private Health _health;

        private void Awake()
        {
            _health = new Health(_healthValue);
        }

        private void OnEnable()
        {
            _takeDamageButton.onClick.AddListener(OnTakeDamageButtonClick);
            _health.Die += OnDie;
        }


        private void OnDisable()
        {
            _takeDamageButton.onClick.RemoveListener(OnTakeDamageButtonClick);
            _health.Die -= OnDie;
        }

        private void OnTakeDamageButtonClick()
        {
            var health = new ArcherArmor(new WarriorArmor(_health, 3), 2);
            health.TakeDamage(_damage);

            Debug.Log(_health.Value);
        }
        private void OnDie()
        {
            Debug.Log("Die");
        }
    }
}