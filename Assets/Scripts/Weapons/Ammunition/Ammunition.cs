using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ammunition : MonoBehaviour
{
    List<WeaponAmmo> AmmoList = new List<WeaponAmmo>();
    public Dictionary<WeaponTypes, int> AmmoDictionary;

    public UnityEvent OnAmmoChanged;

    public void ListToDictionary()
    {
        AmmoDictionary = new Dictionary<WeaponTypes, int>();

        foreach (var ammo in AmmoList) 
            if (!AmmoDictionary.ContainsKey(ammo.WeaponType))
                AmmoDictionary.Add(ammo.WeaponType, ammo.Ammo);
    }

    public bool CheckAmmo(WeaponTypes type)
    {
        if (!AmmoDictionary.ContainsKey(type))
            return false;
        if (AmmoDictionary[type] < 1)
            return false;

        return true;
    }

    public bool GetAmmo(WeaponTypes type)
    {
        if (!CheckAmmo(type))
            return false;

        AmmoDictionary[type]--;
        OnAmmoChanged?.Invoke();

        return true;
    }

    private void Start()
    {
        ListToDictionary();
        OnAmmoChanged?.Invoke();
    }
}