using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _charController;
    private Vector3 _playerVelocity;

    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _gravity = -9.8f;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _charController.isGrounded;
    }

    // Receive the inputs for out InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _charController.Move(transform.TransformDirection(moveDirection) * _playerSpeed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;

        _charController.Move(_playerVelocity * Time.deltaTime);
    }
}
