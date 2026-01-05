using Admiral.Movement.Motor;
using UnityEngine;

namespace Admiral.Movement.Modules
{
    public class AccelerationModule : MovementModuleBase
    {
        [SerializeField] private float acceleration = 40f;
        [SerializeField] private float deceleration = 60f;
        
        public override void Tick(CharacterMotor motor, float deltaTime)
        {
            Vector3 currentVelocity = motor.Velocity;
            Vector3 desiredVelocity = motor.DesiredVelocity;
            
            bool accelerating = desiredVelocity.magnitude > currentVelocity.magnitude;
            float rate = accelerating ? acceleration : deceleration;
            
            Vector3 newVelocity = Vector3.MoveTowards(currentVelocity, desiredVelocity, rate * deltaTime);
            
            motor.SetVelocity(newVelocity);
        }
    }
}
