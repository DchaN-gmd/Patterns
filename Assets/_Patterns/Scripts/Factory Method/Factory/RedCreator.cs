using UnityEngine;

namespace Factory
{
    public class RedCreator : Creator
    {
        public override Mage FactoryMethod()
        {
            var mage = GameObject.Instantiate(MagePrefab);
            var fireMage = mage.GetComponent<FireMage>();
            fireMage.Init(2f, 2.4f);
            return fireMage;
        }

        public RedCreator(Mage magePrefab) : base(magePrefab) { }
    }
}
