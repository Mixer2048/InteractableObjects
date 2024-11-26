using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Transform weaponHolder;

    int selectedWeaponIndex = 0;

    void Start()
    {
        foreach(Transform child in weaponHolder)
            child.gameObject.SetActive(false);
    }

    public CWeapon selectNextWeapon()
    {
        foreach (Transform child in weaponHolder)
            child.gameObject.SetActive(false);

        selectedWeaponIndex++;

        if (selectedWeaponIndex > weaponHolder.childCount - 1)
            selectedWeaponIndex = 0;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }

    public CWeapon selectPrevWeapon()
    {
        foreach (Transform child in weaponHolder)
            child.gameObject.SetActive(false);

        selectedWeaponIndex--;

        if (selectedWeaponIndex < 0)
            selectedWeaponIndex = weaponHolder.childCount - 1;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }

    public CWeapon getSelectedWeapon()
    {
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }

    public CWeapon selectWeaponByIndex(int ind)
    {
        foreach (Transform child in weaponHolder)
            child.gameObject.SetActive(false);

        if (ind > -1 && ind <= weaponHolder.childCount)
        {
            selectedWeaponIndex = ind;
            weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
            return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
        }
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();//ѕришлось добавить, чтобы всЄ возвращало значение, так как методь перестал быть void
    }
}
