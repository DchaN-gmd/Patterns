using UnityEngine.PlayerLoop;

namespace AbstractFactory
{
    public abstract class UnitsFactory
    {
        protected Knight KnightPrefab;
        protected Archer ArcherPrefab;
        protected Mage MagePrefab;

        public void Init(Knight knightPrefab, Archer archerPrefab, Mage magePrefab)
        {
            KnightPrefab = knightPrefab;
            ArcherPrefab = archerPrefab;
            MagePrefab = magePrefab;
        }

        public abstract Knight CreateKnight();
        public abstract Archer CreateArcher();
        public abstract Mage CreateMage();
    }
}
