using UnityEngine;
using System.Text;
using Admiral.Movement.Motor;

namespace Admiral.Movement.Tools
{
    //Debug tool that access motor to display movementModules
    public class MovementDebugOverlay : MonoBehaviour
    {
        private CharacterMotor _characterMotor;

        void Awake()
        {
            _characterMotor = GetComponent<CharacterMotor>();
            if (_characterMotor is null)
            {
                Debug.LogError($"{nameof(MovementDebugOverlay)} requires a component of type {nameof(CharacterMotor)} to function", this);
            }
        }

        void OnGUI()
        {
            if(_characterMotor is null) return;
            
            var modules = _characterMotor.GetModules();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Movement Modules:");

            foreach (var module in modules)
            {
                sb.AppendLine($"{module.Priority} | {(module.ModuleEnabled ? "ON " : "OFF")} | {module.GetType().Name}");
            }
            sb.AppendLine($"Character Velocity:{_characterMotor.Velocity.magnitude:F2} | Desired:{_characterMotor.DesiredVelocity.magnitude:F2}");
            
            GUI.Box(new Rect(10, 10, 260, 20 + modules.Count * 20), sb.ToString());
        }
    }
}