using UnityEngine;

[RequireComponent(typeof(PlasmaGunLogic))]

public class CPlasmaGun : CWeapon
{
    private PlasmaGunLogic plasmagunLogic;

    private void Start()
    {
        plasmagunLogic = GetComponent<PlasmaGunLogic>();
    }

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        plasmagunLogic.shot(firePoint);
    }

    public override WeaponTypes GetWeaponType()
    {
        return WeaponTypes.Plasmagun;
    }
}