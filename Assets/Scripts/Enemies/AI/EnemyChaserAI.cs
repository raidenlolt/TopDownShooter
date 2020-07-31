using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
	public class EnemyChaserAI : EnemyAI
	{
        EnemyChaseState chaseState;

        protected new void Start()
        {
            base.Start();

            chaseState = new EnemyChaseState(this);
            chaseState.EnteredAttackRange += OnEnteredAttackRange;
            SwitchState(chaseState);
        }

        private void OnEnteredAttackRange()
        {
            var health = Target.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.Value -= 10;
                Destroy(gameObject);
            }
        }
    }
}
