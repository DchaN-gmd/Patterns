namespace AbstractFactory
{
    public abstract class Mage : Unit
    {
        private void Start()
        {
            Cast();
        }

        protected abstract void Cast();
    }
}
