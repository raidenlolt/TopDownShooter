using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace VM.Util
{
	public static class Utils 
	{
	    public static Vector3 GetMouseWorldPosition()
	    {
	        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        vec.z = 0f;
	        return vec;
	    }

		public static Vector3 GetRandomDirection()
        {
			return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }

        public static Vector3 RandomNavmeshLocation(Vector3 position, float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
    }
}
