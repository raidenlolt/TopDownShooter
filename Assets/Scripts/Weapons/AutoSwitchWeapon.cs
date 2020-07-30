using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.WeaponSystem
{
	public class AutoSwitchWeapon : MonoBehaviour
	{
        [SerializeField] WeaponsHandler weaponsHandler;
        [SerializeField] float timeBetweenSwitches = 2f;

        public float TimeBetweenSwitches { get { return timeBetweenSwitches; } }

        float timeSinceLastSwitch;
        int currentWeaponIndex;

        private void Reset()
        {
            timeSinceLastSwitch = 0;
            currentWeaponIndex = 0;
            weaponsHandler.SwitchWeapon(currentWeaponIndex);
        }

        private void Start()
        {
            if(weaponsHandler == null)
            {
                Debug.LogError("[" + nameof(AutoSwitchWeapon) + "]: WeaponHandler not setup.");
            }
            Reset();
        }

        private void Update()
        {
            timeSinceLastSwitch += Time.deltaTime;

            if (timeSinceLastSwitch >= timeBetweenSwitches)
            {
                timeSinceLastSwitch = 0;
                currentWeaponIndex = (currentWeaponIndex + 1 >= weaponsHandler.TotalWeaponsCount) ? 0 : currentWeaponIndex + 1;
                weaponsHandler.SwitchWeapon(currentWeaponIndex);
            }
        }
    }
}
