using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace VM.TopDown.Player
{
	public class PlayerAimAndShoot : MonoBehaviour
	{
		[SerializeField] WeaponSystem.WeaponShootingSystem shootingSystem;

		private Vector2 aim;

		// Update is called once per frame
		void Update()
	    {
	        aim.x = CrossPlatformInputManager.GetAxisRaw("MouseX");
			aim.y = CrossPlatformInputManager.GetAxisRaw("MouseY");
			//Debug.Log("aim.sqrMagnitude:" + aim.sqrMagnitude.ToString());
			var aimDirection = aim.normalized;
			float angleInDeg = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angleInDeg);

			if (aim.sqrMagnitude > 0.6f)
			{
				shootingSystem.ShootBullet();
			}
		}
	}
}
