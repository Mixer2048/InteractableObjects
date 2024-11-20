using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShotgunLogic))]
public class CLaserShotgun : CWeapon
{
    ShotgunLogic shotgunLogic;

    private void Start()
    {
        shotgunLogic = GetComponent<ShotgunLogic>();
    }

    public override void fire()
    {
        base.fire();

        shotgunLogic.shot(firePoint, damage);
    }
}
