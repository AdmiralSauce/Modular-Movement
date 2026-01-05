using Admiral.Movement.Motor;

namespace Admiral.Movement.Modules
{
    public interface IMovementModule
    {
        int Priority { get; }
        bool ModuleEnabled { get; }
        
        void Tick(CharacterMotor motor, float deltaTime);
    }
}