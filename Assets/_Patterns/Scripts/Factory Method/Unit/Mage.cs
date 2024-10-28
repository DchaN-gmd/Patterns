using System;
using UnityEngine;

namespace Factory
{
    public abstract class Mage : MonoBehaviour
    {
        protected float CastRange;

        protected void Init(float castRange)
        {
            CastRange = castRange;
        }

        public abstract void Cast();
    }
}