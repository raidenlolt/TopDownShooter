using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VM.TopDown.Enemy
{
	[RequireComponent(typeof(HealthComponent))]
	public class EnemyDeath : MonoBehaviour
	{
        public System.Action enemyDied;

		HealthComponent health;

        private void Awake()
        {
            health = GetComponent<HealthComponent>();
            health.valueChanged += OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            if(value <= 0f)
            {
                //EnemyDeath
                enemyDied?.Invoke();
            }
        }
    }
}
