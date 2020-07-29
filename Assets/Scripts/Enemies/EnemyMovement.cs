using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float tolerance;
        public bool HasReachedPosition { get { return Vector3.Distance(transform.position, targetPosition) < tolerance; } }
        private Rigidbody2D rb;
        private Vector3 targetPosition;
        private Vector2 movement;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            targetPosition = transform.position;
        }

        private void Update()
        {
            movement = Vector3.zero;

            if(!HasReachedPosition)
            {
                movement = (targetPosition - transform.position).normalized;
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    }
}
