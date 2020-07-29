using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VM.Common
{
    public class ValueComponent : MonoBehaviour
    {
        public System.Action<float> valueChanged;

        [SerializeField] protected float value;
        public float Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    valueChanged?.Invoke(value);
                }
            }
        }
    }
}