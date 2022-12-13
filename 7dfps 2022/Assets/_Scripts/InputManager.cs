using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.PlayerActions _playerActions;

    private PlayerMovement _playerMovement;
    private PlayerCamera _playerCamera;

    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerActions = _playerInput.Player;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        // Tell the PlayerMovement to move using the value from our movement action
        _playerMovement.ProcessMove(_playerActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _playerCamera.ProcessLook(_playerActions.Camera.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }
}
