using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.WeaponSystem
{
    [RequireComponent(typeof(WeaponShootingSystem))]
	public class WeaponsHandler : MonoBehaviour
	{
		[SerializeField] Weapon[] weapons;
        WeaponShootingSystem shootingSystem;

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

            shootingSystem.SetCurrentWeapon(weapons[0]);
        }

        public void SwitchWeapon(int index)
        {
            if(index < weapons.Length)
            {
                shootingSystem.SetCurrentWeapon(weapons[index]);
            }
            else
            {
                Debug.LogWarning("[WeaponsHandler] Switching to non existing weapon index.");
            }
        }
    }
}
