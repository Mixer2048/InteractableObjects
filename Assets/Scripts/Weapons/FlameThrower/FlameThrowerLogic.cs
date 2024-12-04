using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;

    public void shot(Transform firePoint, float damage, float length)
    {
        RaycastHit[] hits;

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        hits = Physics.RaycastAll(ray, length, enemy);;

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Health enemyHP = hits[i].transform.GetComponent<Health>();

                if (enemyHP != null)
                    enemyHP.hpDecrease(damage);
            }
        }
    }
}
