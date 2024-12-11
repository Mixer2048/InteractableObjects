using UnityEngine;

public class PlasmaGunLogic : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void shot(Transform firePoint) => Instantiate(projectile, firePoint.position, Quaternion.LookRotation(firePoint.up));
}
