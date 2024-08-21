using System;
using UnityEngine.InputSystem;

public class Player
{
    private PlayerInputSystem _inputSystem;
    private PlayerCharacter _character;

    public Player(PlayerInputSystem inputSystem, PlayerCharacter character)
    {
        _inputSystem = inputSystem ?? throw new ArgumentNullException(nameof(inputSystem));
        _character = character != null ? character : throw new ArgumentNullException();
    }

    public void Enable()
    {
        _inputSystem.Character.Move.performed += OnMove;
        _inputSystem.Character.Move.canceled += OnMove;
        _inputSystem.Character.Shoot.performed += OnShoot;
        _inputSystem.Character.Shoot.canceled += OnShootCancel;

        _inputSystem.Character.Enable();
    }

    public void Disable()
    {
        _inputSystem.Character.Move.performed -= OnMove;
        _inputSystem.Character.Move.canceled -= OnMove;
        _inputSystem.Character.Shoot.performed -= OnShoot;
        _inputSystem.Character.Shoot.canceled -= OnShootCancel;
    }

    private void OnShoot(InputAction.CallbackContext context) => 
        _character.SetShootState(true);

    private void OnShootCancel(InputAction.CallbackContext context) => 
        _character.SetShootState(false);

    private void OnMove(InputAction.CallbackContext context)
    {
        float direction = context.ReadValue<float>();

        _character.SetDirection(direction);
    }
}