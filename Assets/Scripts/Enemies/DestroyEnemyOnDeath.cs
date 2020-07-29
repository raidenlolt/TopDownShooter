using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Enemy
{
	[RequireComponent(typeof(EnemyDeath))]
	public class DestroyEnemyOnDeath : MonoBehaviour
	{
		EnemyDeath death;

        private void Awake()
        {
            death = GetComponent<EnemyDeath>();
            death.enemyDied += () => { Destroy(gameObject); };
        }
    }
}
