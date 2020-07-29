using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Player
{
	public class PlayerShooting : MonoBehaviour
	{
	    [SerializeField] Transform firePoint;
	    [SerializeField] GameObject bulletPrefab;
	    [SerializeField] float bulletForce;
	
	    // Update is called once per frame
	    void Update()
	    {
	        if(Input.GetButtonDown("Fire1"))
	        {
	            ShootBullet();
	        }
	    }
	
	    protected void ShootBullet()
	    {
	        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
	        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	    }
	}
}
