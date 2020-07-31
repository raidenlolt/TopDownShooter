using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.TopDown.Player
{
	[RequireComponent(typeof(HealthComponent))]
	public class PlayerDeath : MonoBehaviour
	{
        public System.Action PlayerDied;
		HealthComponent health;

        private void Awake()
        {
			health = GetComponent<HealthComponent>();
        }
        // Start is called before the first frame update
        void Start()
	    {
			health.valueChanged += OnHealthValueChanged;
	    }

        private void OnHealthValueChanged(float value)
        {
            if(value <= 0)
            {
                PlayerDied?.Invoke();
            }
        }
	}
}
