using System;
using UnityEngine.Serialization;

namespace Decorator
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
    }
}

