using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public WeaponSelector weaponSelector;
    public WeaponScript weaponScript;

    public int numberOfWeapons = 4;

    void Start() => weaponScript.setWeapon(weaponSelector.selectWeaponByIndex(0));

    void Update()
    {
        float mouseWheelDelta = Input.GetAxisRaw("Mouse ScrollWheel");
        if (mouseWheelDelta > 0) weaponScript.setWeapon(weaponSelector.selectNextWeapon());
        if (mouseWheelDelta < 0) weaponScript.setWeapon(weaponSelector.selectPrevWeapon());
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.KeyDown)
        {
            int k = (int)(e.keyCode - KeyCode.Alpha0);
            if (!(k > 0 && k <= numberOfWeapons))
            {
                k = (int)(e.keyCode - KeyCode.Keypad0);

                if (!(k > 0 && k <= numberOfWeapons))
                    return;
            }
            weaponScript.setWeapon(weaponSelector.selectWeaponByIndex(k - 1));
        }
        if (e.type == EventType.MouseDown)
            if (e.button == 0)
                weaponScript.fireStart();

        if (e.type == EventType.MouseUp)
            if (e.button == 0)
                weaponScript.fireEnd();
    }
}
