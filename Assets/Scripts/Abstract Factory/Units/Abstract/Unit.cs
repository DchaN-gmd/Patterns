using UnityEngine;
using UnityEngine.Serialization;

namespace  AbstractFactory
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] [Min(0)] protected int Health;
        [SerializeField] [Min(0)] protected int AttackValue;
    }
}
