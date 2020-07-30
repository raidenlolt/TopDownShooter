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
    }

    [CreateAssetMenu(fileName ="New Damage Type", menuName = "WeaponSystem/DamageType")]
    public class DamageType : ScriptableObject
    {
        public DamageTypes type;
        public float value;
        public bool isPersistant;
        [ConditionalField(nameof(type), false, DamageTypes.Radial)] public float radius;
        [ConditionalField(nameof(isPersistant))] public float lifetime;
        public bool hasHitEffect;
        [ConditionalField(nameof(hasHitEffect))] public GameObject HitEffect;
    }
}
