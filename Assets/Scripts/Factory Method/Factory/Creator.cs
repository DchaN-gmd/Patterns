namespace Factory
{
    public abstract class Creator
    {
        protected Mage MagePrefab;

        public Creator(Mage magePrefab)
        {
            MagePrefab = magePrefab;
        }

        public abstract Mage FactoryMethod();
    }
}
