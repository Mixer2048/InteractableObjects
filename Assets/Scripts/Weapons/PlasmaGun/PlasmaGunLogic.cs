using UnityEngine;

public class PlasmaGunLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [SerializeField] GameObject projectile;
    [SerializeField, Range(1f, 20f)] public float lifeTime = 2f;
    [SerializeField, Range(1f, 20f)] public float speed = 5f;

    public void shot(Transform firePoint, float damage)
    {
        //RaycastHit hit;

        //if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 1000f, enemy))
        //{

        //}

        Instantiate(projectile, firePoint.position, firePoint.rotation);

        //projectile.SetDamage(damage);
    }
}
