using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
	}
}
