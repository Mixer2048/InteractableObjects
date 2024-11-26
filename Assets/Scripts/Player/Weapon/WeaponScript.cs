using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ammunition))]
public class WeaponScript : MonoBehaviour
{
    CWeapon currentWeapon;
    Ammunition ammunition;
    bool isFiring = false;

    private void Awake() => ammunition = GetComponent<Ammunition>();

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
        {
            if (isFiring)
                if (ammunition.CheckAmmo(currentWeapon.GetWeaponType()))
                {
                    if (currentWeapon.canFire)
                    {
                        if (currentWeapon.weaponEffect != null)
                            if (currentWeapon.weaponEffect.isPlaying == false)
                                currentWeapon.weaponEffect.Play();

                        currentWeapon.fire(ammunition);
                    }
                }
                else if (currentWeapon.weaponEffect != null)
                    currentWeapon.weaponEffect.Stop();
        }
    }
}
