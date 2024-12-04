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

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        flameThrowerLogic.shot(firePoint, damage, weaponEffect.shape.length);
    }

    public override WeaponTypes GetWeaponType()
    {
        return WeaponTypes.Flamer;
    }
}
