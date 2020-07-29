using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Damage
{
    public enum DamageTypes
    {
        Point,
        Radial,
        Persistant,
    }

    [CreateAssetMenu(fileName ="New Damage Type", menuName = "WeaponSystem/DamageType")]
    public class DamageType : ScriptableObject
    {
        public DamageTypes type;
        [ConditionalField(nameof(type), false, DamageTypes.Radial)] public float radius;
        [ConditionalField(nameof(type), false, DamageTypes.Persistant)] public float lifetime;
        public GameObject HitEffect;
    }
}
