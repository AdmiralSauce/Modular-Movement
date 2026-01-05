using Admiral.Movement.Motor;
using UnityEngine;

namespace Admiral.Movement.Modules
{
    public abstract class MovementModuleBase : MonoBehaviour, IMovementModule
    {
        [SerializeField] private bool moduleEnabled = true;
        [SerializeField] private int priority = 10;
    
        public int Priority => priority;
        public bool ModuleEnabled
        {
            get => moduleEnabled;
            set => moduleEnabled = value;
        }

        public abstract void Tick(CharacterMotor motor, float deltaTime);
    }
}
