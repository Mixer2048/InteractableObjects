using System;

public enum WeaponTypes { Machinegun, Shotgun, Flamer, Plasmagun };

[Serializable]
public class WeaponAmmo
{
    public WeaponTypes WeaponType;
    public int Ammo;
}