using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyLookAtPosition))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float minRoamRange = 2f;
        [SerializeField] float maxRoamRange = 7f;
        EnemyMovement enemyMovement;
        EnemyLookAtPosition enemyAiming;
        Vector3 startingPosition;
        Vector3 roamPosition;
        Transform target;

        private void Awake()
        {
            enemyMovement = GetComponent<EnemyMovement>();
            enemyAiming = GetComponent<EnemyLookAtPosition>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Start()
        {
            startingPosition = transform.position;
            roamPosition = GetRandomPosition();
        }

        private void Update()
        {
            enemyMovement.SetTargetPosition(roamPosition);
            enemyAiming.SetPositionToLookAt(roamPosition);

            if (enemyMovement.HasReachedPosition)
            {
                roamPosition = GetRandomPosition();
            }
        }

        Vector3 GetRandomPosition()
        {
            return startingPosition + Util.Utils.GetRandomDirection() * Random.Range(minRoamRange, maxRoamRange);
        }

        private void FindTarget()
        {
            float targetRange = 50f;


            if (Vector3.Distance(transform.position, target.position) < targetRange)
            {

            }
        }
    }
}
