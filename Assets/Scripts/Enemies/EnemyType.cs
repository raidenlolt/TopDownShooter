using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace VM.TopDown.Enemy
{
	public enum EnemyTypes
	{
	    Chaser,
	    Patroller,
	}
	
	[CreateAssetMenu(fileName = "New Enemy Type", menuName = "GameData/Enemy/EnemyType")]
	public class EnemyType : ScriptableObject
	{
	    public EnemyTypes type;
		public float attackRange;
		public float pathUpdateDistance;
		[ConditionalField(nameof(type), false, EnemyTypes.Patroller)] public float patrolRadius;
	}
}
