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
    private PlayerAction _playerAction;

    public bool rightGunShootInput { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerActions = _playerInput.Player;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
        _playerAction = GetComponent<PlayerAction>();
    }

    private void Update()
    {
        HandleRightGunShootInput();
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
        _playerActions.RightGunShoot.performed += i => rightGunShootInput = true;

        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void HandleRightGunShootInput()
    {
        if (rightGunShootInput)
        {
            rightGunShootInput = false;
            _playerAction.ProcessAction();
        }
    }
}
