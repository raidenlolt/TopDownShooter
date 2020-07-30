using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VM.TopDown.WeaponSystem;

namespace VM.TopDown.UI
{
	[RequireComponent(typeof(Image))]
	public class CurrentWeaponUI : MonoBehaviour
	{
        [SerializeField] WeaponSystem.WeaponsHandler weaponsHandler;
		Image weaponImage;

        private void Awake()
        {
            weaponImage = GetComponent<Image>();
        }

        private void OnSwitchWeapon(Weapon weapon)
        {
            weaponImage.sprite = weapon.uiImage;
        }

        private void Start()
        {
            weaponsHandler.SwitchingWeapon += OnSwitchWeapon;

        }
    }
}
