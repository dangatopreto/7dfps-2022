using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _playerCam;
    private float _xRotation = 0f;

    [SerializeField] private float _xSensitivity = 30f;
    [SerializeField] private float _ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate camera rotation for looking up and down
        _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        // Apply this to our camera transform
        _playerCam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        // Rotate the player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
    }
}
