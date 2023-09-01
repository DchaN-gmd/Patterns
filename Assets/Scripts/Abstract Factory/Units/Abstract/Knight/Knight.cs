namespace AbstractFactory
{
    public abstract class Knight : Unit
    {
        private void Start()
        {
            Attack();
        }

        protected abstract void Attack();
    }
}
