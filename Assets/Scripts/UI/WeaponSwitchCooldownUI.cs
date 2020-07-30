using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VM.TopDown.WeaponSystem;

namespace VM.TopDown.UI
{
    [RequireComponent(typeof(Image))]
	public class WeaponSwitchCooldownUI : MonoBehaviour
	{
		[SerializeField] AutoSwitchWeapon autoSwitchHandler;

        Image cooldownImage;
        float timeBetweenSwitches;
        float timeSinceLastSwitch;

        private void Awake()
        {
            if(autoSwitchHandler == null)
            {
                Debug.LogError("[" + nameof(WeaponSwitchCooldownUI) + "]: AutoSwitchWeapon script not referenced.");
            }

            cooldownImage = GetComponent<Image>();
        }

        private void Reset()
        {
            timeBetweenSwitches = autoSwitchHandler.TimeBetweenSwitches;
            timeSinceLastSwitch = 0;
        }

        private void Start()
        {
            Reset();
        }


        private void Update()
        {
            timeSinceLastSwitch += Time.deltaTime;

            cooldownImage.fillAmount = timeSinceLastSwitch / timeBetweenSwitches;

            if (timeSinceLastSwitch >= timeBetweenSwitches)
                timeSinceLastSwitch = 0;
        }
    }
}
