using Admiral.Movement.Input;
using Admiral.Movement.Motor;
using UnityEngine;

/*
 * Decides how velocity is added
 * Does not move the character directly
 * Logic for movement
 */
    
namespace Admiral.Movement.Modules
{
    // Example Movement Module: Walks Character in Inputted direction 
    // WalkModule does not “handle input" it consumes movement intent
    public class WalkModule : MovementModuleBase
    {
        //TEMP
        [SerializeField] private MonoBehaviour inputSource;
        
        [SerializeField] private float maxSpeed = 10f;
        
        private IMovementInput _input;

        void Awake()
        {
            // TEMP: Should be Replaced with Core Service Input Handler Getter
            _input = inputSource as IMovementInput;

            if (_input is null)
            {
                Debug.LogError($"{nameof(WalkModule)} requires a component implementing {nameof(IMovementInput)}", this);
            }
        }

        public override void Tick(CharacterMotor motor, float dt)
        {
            if (_input is null) return;
            
            Vector3 move =
                new Vector3(_input.Move.x, 0, _input.Move.y);
            
            if (move.sqrMagnitude > 1f) move.Normalize();

            motor.AddDesiredVelocity(move * maxSpeed);
        }
    }
}
