using System.Collections.Generic;
using System.Linq;
using Admiral.Movement.Modules;
using UnityEngine;

/*
 * Moves the character
 * Knows physics, grounding, collision
 * Motor doesn’t know what movement exists
 * Modules contribute velocity
 * Order doesn’t matter
 * New mechanics are just new modules
 */

namespace Admiral.Movement.Motor
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMotor : MonoBehaviour
    {
        public Vector3 Velocity { get; private set; }
        public Vector3 DesiredVelocity { get; set; }
        
        private CharacterController _controller;
        private List<IMovementModule> _movementModules;
        
        void Awake()
        {
            _controller = GetComponent<CharacterController>();
            RebuildModuleOrder();
        }
        
        void Update()
        {
            var dt = Time.deltaTime;
            
            //reset the intent every frame
            DesiredVelocity = Vector3.zero;

            foreach (var module in _movementModules)
            {
                if(!module.ModuleEnabled) continue;
                module.Tick(this, dt);
            }
            _controller.Move(Velocity * dt);
        }

        public void SetVelocity(Vector3 v)
        {
            Velocity = v;
        }
        
        public void AddDesiredVelocity(Vector3 v)
        {
            DesiredVelocity += v;
        }

        public void MultiplyVelocity(float factor)
        {
            Velocity *= factor;
        }
        
        private void RebuildModuleOrder()
        {
            _movementModules = GetComponents<IMovementModule>()
                .OrderBy(m => m.Priority)
                .ToList();
        }
        
        public bool IsGrounded => _controller.isGrounded;

        public IReadOnlyList<IMovementModule> GetModules()
        {
            return _movementModules;
        }
    }
}