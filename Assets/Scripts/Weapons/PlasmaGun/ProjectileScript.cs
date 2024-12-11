using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] public float lifeTime = 2f;
    [SerializeField, Range(1f, 20f)] public float speed = 5f;
    [SerializeField, Range(0f, 100f)] public float damage = 10f;
    [SerializeField, Range(0f, 50f)] public float radius = 5f;

    [SerializeField] GameObject explosionEffect;
    [SerializeField] LayerMask enemy;
    [SerializeField] LayerMask player;

    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        //transform.rotation *= Quaternion.Euler(-90, 0, 0);

        StartCoroutine(LifeTime());
    }

    private void FixedUpdate()
    {
        body.position += -transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == player) return;

        GameObject exp = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(exp, 2f);

        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemy);

        foreach (Collider enemy in enemies)
        {
            Health enemyHP = enemy.transform.GetComponent<Health>();

            if (enemyHP != null)
                enemyHP.hpDecrease(damage);
        }
        
        Destroy(gameObject);
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
