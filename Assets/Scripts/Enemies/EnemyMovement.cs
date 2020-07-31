using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace VM.TopDown.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float tolerance;

        //public bool HasReachedPosition { get { return Vector3.Distance(transform.position, targetPosition) < tolerance; } }
        public bool HasReachedPosition { get { return nma.remainingDistance < tolerance; } }
        public Vector3 LookDirection {  get { return nma.velocity.normalized; } }
        private NavMeshAgent nma;
        //private Vector3 targetPosition;
        private Vector2 movement;

        private void Awake()
        {
            nma = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            nma.updateRotation = false;
            nma.updateUpAxis = false;
            nma.speed = moveSpeed;
            //targetPosition = transform.position;
        }


        //private void FixedUpdate()
        //{
        //    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //}

        public void SetTargetPosition(Vector3 targetPosition)
        {
            //this.targetPosition = targetPosition;
            //nma.SetDestination(targetPosition);
            nma.destination = targetPosition;
        }
    }
}
