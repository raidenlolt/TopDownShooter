using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
    public class EnemyPatrolState : EnemyState
    {
        private EnemyMovement enemyMovement;
        private Vector3 startingPosition;
        private float radius;

        public EnemyPatrolState(EnemyAI owner) : base(owner)
        {
            enemyMovement = owner.GetMovementComponent();
            startingPosition = owner.StartingPosition;
        }

        public override void Tick()
        {
            if (enemyMovement.HasReachedPosition)
            {
                var roamPosition = Util.Utils.RandomNavmeshLocation(startingPosition, radius);
                enemyMovement.SetTargetPosition(roamPosition);
            }
        }
    }
}
