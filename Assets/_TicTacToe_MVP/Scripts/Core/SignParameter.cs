using System;
using UnityEngine;

namespace MVP
{
    [Serializable]
    public struct SignParameter
    {
        [SerializeField] private SignType _type;
        [SerializeField] private Sprite _sprite;

        public SignType Type => _type;
        public Sprite Sprite => _sprite;
    }
}