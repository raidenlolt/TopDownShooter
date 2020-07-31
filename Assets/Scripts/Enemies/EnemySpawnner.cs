using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VM.TopDown.Enemy
{
	public class EnemySpawnner : MonoBehaviour
	{
		Func<EnemyType, GameObject> EnemySpawnFunc;
		
		public void Setup(Func<EnemyType, GameObject> EnemySpawnFunc)
        {
			this.EnemySpawnFunc = EnemySpawnFunc;
        }

	    public void SpawnEnemy(EnemyType enemyType)
	    {
			var Enemy = EnemySpawnFunc(enemyType);
	    }
	}
}
