using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(PlasmaGunLogic))]

public class CPlasmaGun : CWeapon
{
    private TracerSystem tracerSystem;
    private PlasmaGunLogic plasmagunLogic;

    private void Start()
    {
        tracerSystem = GetComponent<TracerSystem>();
        plasmagunLogic = GetComponent<PlasmaGunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        tracerSystem.createTracer(firePoint.position, firePoint.forward);
        plasmagunLogic.shot(firePoint, damage);
    }

    public override WeaponTypes GetWeaponType()
    {
        return WeaponTypes.Plasmagun;
    }
}
