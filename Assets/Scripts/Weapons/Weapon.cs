using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.WeaponSystem
{
	[CreateAssetMenu(fileName ="New Weapon", menuName ="WeaponSystem/Weapon")]
	public class Weapon : ScriptableObject
	{
	    public string Name;
	    public string Description;
	
	    public GameObject bulletPrefab;
	
	    public int magazineCapacity;
	    public float reloadSpeed;
	    public float fireRate;
	    public float damage;
	    public float recoilForce;
		public float bulletForce;
	}
}
