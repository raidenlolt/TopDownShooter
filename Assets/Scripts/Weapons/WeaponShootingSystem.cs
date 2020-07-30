﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.TopDown.Damage;

namespace VM.TopDown.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WeaponShootingSystem : MonoBehaviour
    {
        public System.Action<Weapon> ShotFired;

        [SerializeField] Transform firePoint;

        Rigidbody2D rb;
        Weapon currentWeapon;
        float timeSinceLastShot;
        float reloadTime;
        int shotsFired;
        bool isReloading;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            isReloading = false;
            timeSinceLastShot = 0;
        }

        private void Update()
        {
            if (isReloading)
            {
                reloadTime += Time.deltaTime;

                if (reloadTime >= currentWeapon.reloadSpeed)
                {
                    isReloading = false;
                    shotsFired = 0;
                }
            }

            timeSinceLastShot += Time.deltaTime;
        }

        public Weapon GetCurrentWeapon()
        {
            return currentWeapon;
        }
        public void SetCurrentWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
        }

        public void ShootBullet()
        {
            if (timeSinceLastShot > 1 / currentWeapon.fireRate && !isReloading)
            {
                if (shotsFired == currentWeapon.magazineCapacity - 1)
                {
                    isReloading = true;
                }

                timeSinceLastShot = 0;
                var bullet = Instantiate(currentWeapon.bulletPrefab, firePoint.position, firePoint.rotation);
                var bdc = bullet.GetComponent<DamageComponent>();
                bdc.Setup(currentWeapon.damageType, currentWeapon.damageValue);

                Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
                brb.AddForce(firePoint.up * currentWeapon.bulletForce, ForceMode2D.Impulse);
                rb.AddForce(firePoint.up * -1 * currentWeapon.recoilForce);

                ShotFired?.Invoke(currentWeapon);
            }
        }
    }
}

