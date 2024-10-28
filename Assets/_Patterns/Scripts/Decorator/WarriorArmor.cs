namespace  Decorator
{
    public class WarriorArmor : IDamageable
    {
        private IDamageable _damageable;
        private int _armorValue;

        public WarriorArmor(IDamageable damageable, int armorValue)
        {
            _damageable = damageable;
            _armorValue = armorValue;
        }

        public void TakeDamage(int damage)
        {
            _damageable.TakeDamage(damage - _armorValue);
        }
    }
}