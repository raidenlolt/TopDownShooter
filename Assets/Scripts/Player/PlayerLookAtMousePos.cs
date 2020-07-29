using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.Util;

namespace VM.TopDown.Player
{
	public class PlayerLookAtMousePos : MonoBehaviour
	{
	    private void Update()
	    {
			Vector3 mousePosition = Utils.GetMouseWorldPosition();
			Vector3 aimDirection = (mousePosition - transform.position).normalized;

			float angleInDeg = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angleInDeg);
	    }
	}
}
