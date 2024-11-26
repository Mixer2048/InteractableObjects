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

    public override void fire()
    {
        base.fire();

        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        machinegunLogic.shot(firePoint, damage);
    }
}
