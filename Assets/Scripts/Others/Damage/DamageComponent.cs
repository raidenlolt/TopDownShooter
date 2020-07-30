using UnityEngine;
using VM.TopDown.Damage;

namespace VM.TopDown.Damage
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class DamageComponent : MonoBehaviour
    {
        DamageType damageType;
        float weaponBaseDamageValue;

        public void Setup(DamageType damageType, float weaponBaseDamageValue)
        {
            this.damageType = damageType;
            this.weaponBaseDamageValue = weaponBaseDamageValue;
        }

        public virtual float GetDamageValue()
        {
            return damageType.value + weaponBaseDamageValue;
        }

        private void CauseDamage(Transform target)
        {
            var health = target.GetComponent<HealthComponent>();
            if (health != null)
                health.Value -= GetDamageValue();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(damageType.hasHitEffect && damageType.HitEffect!=null)
            {
                Instantiate(damageType.HitEffect, transform.position, Quaternion.identity);
            }

            switch (damageType.type)
            {
                case DamageTypes.Point:
                    {
                        CauseDamage(collision.transform);

                    }
                    break;
                case DamageTypes.Radial:
                    RaycastHit2D[] hitactors = Physics2D.CircleCastAll(transform.position, damageType.radius, Vector2.zero);
                    foreach (var hitactor in hitactors)
                    {
                        CauseDamage(hitactor.transform);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

