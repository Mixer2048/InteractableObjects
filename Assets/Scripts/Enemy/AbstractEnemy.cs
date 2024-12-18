using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractEnemy : MonoBehaviour, IEnemy
{
    protected Transform player;
    public Health enemyHP;

    [Range(1, 60)]
    public float updatePerSecond = 10;
    [Range(1, 360)]
    public float rotationSpeed = 120;
    [Range(0.1f, 30f)]
    public float shieldTime = 5f;

    public GameObject shield;
    protected GameObject currentShield;
    protected Collider collider;

    NavMeshAgent agent;
    protected Animator animator;
    protected StateMachine stateMachine;

    protected bool stunned = false;
    protected bool dead = false;
    protected bool isInvincible = false;

    public Transform Player
    {
        get { return player; }
        set { player = value; }
    }

    public Health EnemyHP { get { return enemyHP; } }
    
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();

        stateMachine = new StateMachine();

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemyHP.onHitTaken.AddListener(stunBegin);
        enemyHP.onHitTaken.AddListener(FirstHitted);
        enemyHP.onDeath.AddListener(death);

        StartCoroutine(updateCall());
    }

    IEnumerator updateCall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/updatePerSecond);

            updateState();

            if (dead) break;
        }
    }

    public abstract void updateState();

    public virtual void moveTo(Vector3 point)
    {
        agent.SetDestination(point);
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
    public virtual void rotateTo(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed / updatePerSecond);
    }
    public virtual void attack(bool state)
    {
        animator.SetBool("attack", state);
    }
    public virtual void stunBegin()
    {
        stunned = true;
        animator.SetTrigger("getHit");
    }
    public virtual void stunEnd()
    {
        stunned = false;
    }
    public virtual void stop(bool state)
    {
        agent.isStopped = state;
    }
    public void positionAndRotation(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
    }
    public virtual void death()
    {
        dead = true;
        animator.SetTrigger("death");
        stop(true);

        StartCoroutine(despawn());
    }
    IEnumerator despawn()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    public virtual void RocketLaunch(bool state)
    {

    }

    public void FirstHitted()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            //enemyHP.onHitTaken.RemoveListener(FirstHitted);
        }
            
    }

    public virtual void shieldUp()
    {
        currentShield = Instantiate(shield, transform.localPosition, Quaternion.identity);
        collider.enabled = false;

        //StartCoroutine(shieldCooldown());
    }

    public virtual void shieldDown()
    {
        isInvincible = false;
        Destroy(currentShield);
        collider.enabled = true;
    }

    //private IEnumerator shieldCooldown()
    //{
    //    yield return new WaitForSeconds(shieldTime);        
    //}
}
