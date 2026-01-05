using Admiral.Movement.Motor;
using UnityEngine;

namespace Admiral.Movement.Modules
{
    public class SlowModule : MovementModuleBase
    {
        [SerializeField] private float slowFactor = 0.5f;

        public override void Tick(CharacterMotor motor, float deltaTime)
        {
            motor.MultiplyVelocity(slowFactor);
        }
    }
}
