namespace Decorator
{
    public class ArcherArmor : IDamageable
    {
        private IDamageable _damageable;
        private int _agility;

        public ArcherArmor(IDamageable damageable, int agility)
        {
            _damageable = damageable;
            _agility = agility;
        }

        public void TakeDamage(int damage)
        {
            _damageable.TakeDamage(damage / _agility);
        }
    }
}