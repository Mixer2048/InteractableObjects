using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileScript : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] public float lifeTime = 2f;
    [SerializeField, Range(1f, 20f)] public float speed = 5f;
    [SerializeField, Range(0f, 100f)] public float damage = 10f;
    [SerializeField, Range(0f, 50f)] public float radius = 5f;

    [SerializeField] GameObject explosionEffect;
    [SerializeField] LayerMask target;

    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        transform.rotation *= Quaternion.Euler(-90, 0, 0);

        StartCoroutine(LifeTime());
    }

    private void FixedUpdate()
    {
        body.position += -transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radius, target);

        if (targets.Length > 0)
        {
            GameObject exp = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(exp, 2f);

            foreach (Collider target in targets)
            {
                Health targetHP = target.transform.GetComponent<Health>();

                if (targetHP != null)
                    targetHP.hpDecrease(damage);
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
