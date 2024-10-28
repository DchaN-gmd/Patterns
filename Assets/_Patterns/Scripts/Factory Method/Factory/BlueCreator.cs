using UnityEngine;

namespace Factory
{
    public class BlueCreator : Creator
    {
        public override Mage FactoryMethod()
        {
            var mage = GameObject.Instantiate(MagePrefab);
            var blizzardMage = mage.GetComponent<BlizzardMage>();
            blizzardMage.Init(3f, 4.5f);
            return blizzardMage;
        }

        public BlueCreator(Mage magePrefab) : base(magePrefab) { }
    }
}