using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.WeaponSystem
{
    [RequireComponent(typeof(WeaponShootingSystem))]
	public class WeaponsHandler : MonoBehaviour
	{
        public System.Action<Weapon> SwitchingWeapon;

		[SerializeField] Weapon[] weapons;
        WeaponShootingSystem shootingSystem;

        public int TotalWeaponsCount { get { return weapons.Length; } }
        //public Weapon CurrentWeapon { get { return shootingSystem.GetCurrentWeapon(); } }

        private void Awake()
        {
            shootingSystem = GetComponent<WeaponShootingSystem>();
        }

        private void Start()
        {
            if (weapons.Length <= 0)
            {
                Debug.LogError("[WeaponsHandler] No weapons added to WeaponsHandler script.");
                return;
            }
        }

        public void SwitchWeapon(int index)
        {
            if(index < weapons.Length)
            {
                shootingSystem.SetCurrentWeapon(weapons[index]);
                SwitchingWeapon?.Invoke(weapons[index]);
            }
            else
            {
                Debug.LogWarning("[WeaponsHandler] Switching to non existing weapon index.");
            }
        }
    }
}
