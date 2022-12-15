using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerGunSelector : MonoBehaviour
{
    [SerializeField] private GunType _gun;
    [SerializeField] private Transform _gunParent;
    [SerializeField] private List<GunSO> _guns;

    [Space]
    [Header("Runtime Filled")]
    public GunSO activeGun;

    private void Start()
    {
        GunSO gun = _guns.Find(gun => gun.gunType == _gun);

        if (gun == null)
        {
            Debug.LogError($"No GunSO found for gunType: {_gun}");
            return;
        }

        activeGun = gun;
        gun.Spawn(_gunParent, this);
    }
}
