using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(ShotgunLogic))]
public class CLaserShotgun : CWeapon
{
    TracerSystem tracerSystem;
    ShotgunLogic shotgunLogic;

    private void Start()
    {
        tracerSystem = GetComponent<TracerSystem>();
        shotgunLogic = GetComponent<ShotgunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        //shotgunLogic.shot(firePoint, damage);
        List<Vector3> directions = shotgunLogic.shot(firePoint, damage);

        foreach (Vector3 direction in directions)
            tracerSystem.createTracer(firePoint.position, direction);
    }

    public override WeaponTypes GetWeaponType()
    {
        return WeaponTypes.Shotgun;
    }
}
