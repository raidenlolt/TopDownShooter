using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VM.Common.StateSystem;

namespace VM.TopDown.Enemy
{
    public class EnemyState : State<EnemyAI>
    {
        public EnemyState(EnemyAI owner) : base(owner) { }

        public override void Tick()
        {
        }
    }
}
