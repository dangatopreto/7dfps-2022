using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerGunSelector _gunSelector;

    public void ProcessAction()
    {
        if (_gunSelector.activeGun != null)
        {
            _gunSelector.activeGun.Shoot();
        }
    }
}
