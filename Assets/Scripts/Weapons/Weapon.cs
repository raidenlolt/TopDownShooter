using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.TopDown.Damage;

namespace VM.TopDown.WeaponSystem
{
	[CreateAssetMenu(fileName ="New Weapon", menuName ="WeaponSystem/Weapon")]
	public class Weapon : ScriptableObject
	{
	    public string Name;
	    public string Description;
	
	    public GameObject bulletPrefab;
		public Sprite uiImage;
	    public int magazineCapacity;
	    public float reloadSpeed;
	    public float fireRate;
	    public float recoilForce;
		public float bulletForce;
		public float damageValue;
		public DamageType damageType;
	}
}
