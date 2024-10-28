using UnityEngine.Events;

namespace Decorator
{
    public class Health : IDamageable
    {
        public UnityAction Die;

        public int Value { get; private set; }

        public Health(int value)
        {
            Value = value;
        }

        public void TakeDamage(int damage)
        {
            if(damage < 0) damage = 0;

            Value -= damage;

            if (Value < 0) Value = 0;

            if (Value == 0)
            {
                Die?.Invoke();
            }
        }
    }
}