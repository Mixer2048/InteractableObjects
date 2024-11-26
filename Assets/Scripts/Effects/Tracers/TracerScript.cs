using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TracerScript : MonoBehaviour
{
    public float length = 55;
    public float speed = 100;
    public float lifeTime = .3f;

    Vector3 position;
    Vector3 direction;

    LineRenderer lineRenderer;
    public IObjectPool<GameObject> pool;

    private void Awake() => lineRenderer = GetComponent<LineRenderer>();

    public void setPoints(Vector3 position, Vector3 direction)
    {
        this.position = position;
        this.direction = direction;
    }

    void OnEnable() => StartCoroutine(Fade());

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(lifeTime);
        pool.Release(gameObject);
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, position);
        lineRenderer.SetPosition(1, position + direction * length);
        position += direction * speed * Time.deltaTime;
    }
}
