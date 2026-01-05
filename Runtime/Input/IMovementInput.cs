using UnityEngine;

/*
 *  Movement Intent, is implemented by the Input System
 */

namespace Admiral.Movement.Input
{
    public interface IMovementInput
    {
        Vector2 Move { get; }
        bool JumpPressed { get; }
    }
}