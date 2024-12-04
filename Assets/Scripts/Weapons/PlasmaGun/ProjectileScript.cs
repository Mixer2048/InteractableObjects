using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] public float lifeTime = 2f;
    [SerializeField, Range(1f, 20f)] public float speed = 5f;
    [SerializeField, Range(0f, 100f)] public float damage = 10f;
    //private float lifeTime;
    //private float speed;
    //private float damage;

    [SerializeField] LayerMask enemy;

    Rigidbody body;

    //public void SetLifeTime(float time)
    //{
    //    this.lifeTime = time;
    //}
    //public void SetSpeed(float speed)
    //{
    //    this.speed = speed;
    //}
    //public void SetDamage(float damage)
    //{
    //    this.damage = damage;
    //}

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == enemy)
        {
            Health enemyHP = collision.transform.GetComponent<Health>();

            if (enemyHP != null)
                enemyHP.hpDecrease(damage);
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
