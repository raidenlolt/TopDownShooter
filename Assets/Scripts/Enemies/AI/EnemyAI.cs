using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace VM.TopDown.Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyLookAtPosition))]
    public class EnemyAI : MonoBehaviour
    {
        EnemyMovement enemyMovement;
        EnemyLookAtPosition enemyAiming;
        Vector3 startingPosition;
        Transform target;
        EnemyState currentState;
        [SerializeField] EnemyType enemyType;

        public Vector3 StartingPosition { get { return startingPosition; } }
        public Transform Target { get { return target; } }
        public EnemyType EnemyType { get { return enemyType; } }

        private void Awake()
        {
            enemyMovement = GetComponent<EnemyMovement>();
            enemyAiming = GetComponent<EnemyLookAtPosition>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected void Start()
        {
            startingPosition = transform.position;
        }

        private void Update()
        {
            enemyAiming.SetPositionToLookAt(transform.position + enemyMovement.LookDirection);
            currentState.Tick();
        }

        public virtual void Setup(EnemyType enemyType)
        {
            this.enemyType = enemyType;
        }

        public void SwitchState(EnemyState newState)
        {
            if (newState == null) return;

            if (currentState != null)
            {
                currentState.OnStateExit();
            }

            currentState = newState;
            currentState.OnStateEnter();
        }

        public EnemyMovement GetMovementComponent()
        {
            return enemyMovement;
        }
    }
}
