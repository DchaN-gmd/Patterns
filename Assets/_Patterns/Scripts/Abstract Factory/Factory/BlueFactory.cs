using UnityEngine;

namespace AbstractFactory
{
    public class BlueFactory : UnitsFactory
    {
        public override Knight CreateKnight()
        {
            var knight = GameObject.Instantiate(KnightPrefab);
            var blueKnight = knight.GetComponent<BlueKnight>();
            return blueKnight;
        }

        public override Archer CreateArcher()
        {
            var archer = GameObject.Instantiate(ArcherPrefab);
            var blueArcher = archer.GetComponent<BlueArcher>();
            blueArcher.Init(2f);
            return blueArcher;
        }

        public override Mage CreateMage()
        {
            var mage = GameObject.Instantiate(MagePrefab);
            var blueMage = mage.GetComponent<BlueMage>();
            return blueMage;
        }
    }
}