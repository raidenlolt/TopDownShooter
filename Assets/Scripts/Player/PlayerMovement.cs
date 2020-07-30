using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace VM.TopDown.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMovement : MonoBehaviour
	{
	    [SerializeField] private float moveSpeed = 5f;
	
	    private Rigidbody2D rb;
	    private Vector2 movement;

		bool freezePlayer;

        private void Awake()
        {
			rb = GetComponent<Rigidbody2D>();
		}

        private void Start()
	    {
			freezePlayer = false;
	    }
	
	    private void Update()
	    {
	        movement.x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
	        movement.y = CrossPlatformInputManager.GetAxisRaw("Vertical");
	    }
	
	    private void FixedUpdate()
	    {
			if (freezePlayer) return;

	        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	    }

		public void FreezePlayer()
        {
			freezePlayer = true;
        }

		public void UnfreezePlayer()
        {
			freezePlayer = false;
        }
	}
}
