using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void fire(Ammunition ammunition);
    public WeaponTypes GetWeaponType();
}
