using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.Util;

namespace VM.TopDown.Game
{
	public class CameraFollowsPlayer : MonoBehaviour
	{
		[SerializeField] FollowPosition followCam;
		[SerializeField] Transform player;

        private void Start()
        {
            followCam.Setup(() => player.transform.position);
        }
    }
}
