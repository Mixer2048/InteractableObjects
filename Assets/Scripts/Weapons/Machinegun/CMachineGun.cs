using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(MachinegunLogic))]

public class CMachineGun : CWeapon
{
    TracerSystem tracerSystem;
    MachinegunLogic machinegunLogic;

    void Start()
    {
        tracerSystem = GetComponent<TracerSystem>();
        machinegunLogic = GetComponent<MachinegunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        machinegunLogic.shot(firePoint, damage);
    }

    public override WeaponTypes GetWeaponType()
    {
        return WeaponTypes.Machinegun;
    }
}
