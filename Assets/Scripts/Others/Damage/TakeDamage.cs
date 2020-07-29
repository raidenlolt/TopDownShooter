using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Damage
{
    [RequireComponent(typeof(HealthComponent))]
    public class TakeDamage : MonoBehaviour
    {
        public System.Action<float> damageTaken;
        HealthComponent health;

        private void Awake()
        {
            health = GetComponent<HealthComponent>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var damageComp = collision.gameObject.GetComponent<DamageComponent>();
            if (damageComp != null && damageComp.Value > 0f)
            {
                health.Value -= damageComp.Value;
                damageTaken?.Invoke(damageComp.Value);
            }
        }
    }
}
