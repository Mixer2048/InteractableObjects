using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlameThrowerLogic))]

public class CFlameThrower : CWeapon
{
    FlameThrowerLogic flameThrowerLogic;
    void Start()
    {
        flameThrowerLogic = GetComponent<FlameThrowerLogic>();
    }

    public override void fire()
    {
        base.fire();

        flameThrowerLogic.shot(firePoint, damage);
    }
}
