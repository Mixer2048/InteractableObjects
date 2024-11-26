using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    CWeapon currentWeapon;
    bool isFiring = false;

    public void setWeapon(CWeapon selectedWeapon)
    {
        fireEnd();
        currentWeapon = selectedWeapon;
        Debug.Log(currentWeapon);
    }

    public void fireStart()
    {
        isFiring = true;
        if (currentWeapon.weaponEffect != null && currentWeapon.canFire)
            currentWeapon.weaponEffect.Play();
    }

    public void fireEnd()
    {
        isFiring = false;
        if (currentWeapon != null)
            if (currentWeapon.weaponEffect != null)
                currentWeapon.weaponEffect.Stop();
    }

    void Update()
    {
        if (currentWeapon != null)
            if (currentWeapon.canFire && isFiring)
            {
                if (currentWeapon.weaponEffect != null)
                    if (currentWeapon.weaponEffect.isPlaying == false)
                        currentWeapon.weaponEffect.Play();

                currentWeapon.fire();
            }
    }
}
