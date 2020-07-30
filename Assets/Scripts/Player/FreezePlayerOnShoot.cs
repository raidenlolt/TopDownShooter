using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.TopDown.WeaponSystem;

namespace VM.TopDown.Player
{
    public class FreezePlayerOnShoot : MonoBehaviour
    {
        [SerializeField] PlayerMovement movement;
        [SerializeField] WeaponShootingSystem shootingSystem;
        [SerializeField] float timeToFreeze = 0.01f;

        private void Awake()
        {
            if (movement == null)
            {
                Debug.LogError("[" + nameof(FreezePlayerOnShoot) + "]: PlayerMovement not set.");
            }
            if (shootingSystem == null)
            {
                Debug.LogError("[" + nameof(FreezePlayerOnShoot) + "]: WeaponShootingSystem not set.");
            }
        }

        private void Start()
        {
            shootingSystem.ShotFired += OnShotFired;
        }

        private void OnShotFired(Weapon weapon)
        {
            StartCoroutine(FreezePlayerMovement());
        }

        IEnumerator FreezePlayerMovement()
        {
            movement.FreezePlayer();

            yield return new WaitForSeconds(timeToFreeze);

            movement.UnfreezePlayer();
        }
    }
}
