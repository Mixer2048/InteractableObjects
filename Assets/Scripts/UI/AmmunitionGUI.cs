using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class WeaponGUI
{
    public WeaponTypes WeaponType;
    public TMP_Text AmmoText;
}

public class AmmunitionGUI : MonoBehaviour
{
    public Ammunition Ammunition;

    public List<WeaponGUI> Weapons;
    Dictionary<WeaponTypes, TMP_Text> WeaponsDictionary;

    public void UpdateGUI()
    {
        foreach (KeyValuePair<WeaponTypes, int> pair in Ammunition.AmmoDictionary)
            if (WeaponsDictionary.ContainsKey(pair.Key))
                WeaponsDictionary[pair.Key].text = pair.Value.ToString();
    }

    private void Awake() => ListToDicitionary();

    private void ListToDicitionary()
    {
        WeaponsDictionary = new Dictionary<WeaponTypes, TMP_Text>();

        foreach (var weapon in Weapons)
            if (!WeaponsDictionary.ContainsKey(weapon.WeaponType))
                WeaponsDictionary.Add(weapon.WeaponType, weapon.AmmoText);

    }
}
