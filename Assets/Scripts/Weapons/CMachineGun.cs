using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MachinegunLogic))]

public class CMachineGun : CWeapon
{
    MachinegunLogic machinegunLogic;

    void Start()
    {
        machinegunLogic = GetComponent<MachinegunLogic>();
    }

    public override void fire()
    {
        base.fire();

        machinegunLogic.shot(firePoint, damage);
    }
}
