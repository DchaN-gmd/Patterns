using UnityEngine;

namespace AbstractFactory
{
    public class RedFactory : UnitsFactory
    {
        public override Knight CreateKnight()
        {
            var knight = GameObject.Instantiate(KnightPrefab);
            var redKnight = knight.GetComponent<RedKnight>();
            return redKnight;
        }

        public override Archer CreateArcher()
        {
            var archer = GameObject.Instantiate(ArcherPrefab);
            var redArcher = archer.GetComponent<RedArcher>();
            redArcher.Init(0.8f);
            return redArcher;
        }

        public override Mage CreateMage()
        {
            var mage = GameObject.Instantiate(MagePrefab);
            var redMage = mage.GetComponent<RedMage>();
            return redMage;
        }
    }
}