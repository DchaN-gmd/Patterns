namespace Decorator
{
    public class WizardArmor : IDamageable
    {
        private IDamageable _damageable;
        private int _manaShield;
        private int _manaValue;

        public WizardArmor(IDamageable damageable, int manaShield, int manaValue)
        {
            _damageable = damageable;
            _manaShield = manaShield;
            _manaValue = manaValue;
        }

        public void TakeDamage(int damage)
        {
            _damageable.TakeDamage(damage / (_manaShield * _manaValue));
        }
    }
}
