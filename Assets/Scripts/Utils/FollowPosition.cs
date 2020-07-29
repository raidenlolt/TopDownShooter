using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.Util
{
	public class FollowPosition : MonoBehaviour
	{
	    private Func<Vector3> GetCameraPositionFunc;
	
	    public void Setup(Func<Vector3> GetCameraPositionFunc)
	    {
	        this.GetCameraPositionFunc = GetCameraPositionFunc;
	    }
	
	    private void Update()
	    {
	        Vector3 cameraFollowPosition = GetCameraPositionFunc();
	        cameraFollowPosition.z = transform.position.z;
	        transform.position = cameraFollowPosition;
	    }
	}
}
