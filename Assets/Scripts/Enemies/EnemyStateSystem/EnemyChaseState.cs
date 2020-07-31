using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
    public class EnemyChaseState : EnemyState
    {
        public System.Action EnteredAttackRange;

        public EnemyChaseState(EnemyAI owner) : base(owner)
        {
        }

        public override void OnStateEnter()
        {
            owner.GetMovementComponent().SetTargetPosition(owner.Target.position);
        }

        public override void Tick()
        {
            if (Vector3.Distance(owner.transform.position, owner.Target.position) > owner.EnemyType.pathUpdateDistance)
            {
                owner.GetMovementComponent().SetTargetPosition(owner.Target.position);
            }

            if (Vector3.Distance(owner.Target.position, owner.transform.position) < owner.EnemyType.attackRange)
            {
                EnteredAttackRange?.Invoke();
            }
        }
    }
}