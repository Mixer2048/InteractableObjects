using System.Collections;
using UnityEngine;

public class RangeEnemy : AbstractEnemy
{
    [SerializeField] GameObject rocket;

    [Range(0.1f, 100f)] public float DetectionRange = 20f;
    [Range(1, 10)] public int Damage = 4;
    [Range(1, 10)] public int FireRate = 10;
    [SerializeField] private Transform turretTop;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem shotEffect;

    [Header("Debug")]
    [SerializeField] private bool showGizmo = false;

    TracerSystem tracerSystem;

    Idle _idleState;
    RotateTo _rotateState;
    Attack _attackState;
    RocketLaunch _rocketLaunch;

    [SerializeField, Range(0, 100)] private int rocketInterval = 40;
    private int attackCount;

    private new void Start()
    {
        base.Start();

        if (shotEffect != null)
        {
            var main = shotEffect.main;
            main.duration = 1 / FireRate;
        }

        animator = turretTop.GetComponent<Animator>();

        tracerSystem = GetComponent<TracerSystem>();

        _idleState = new Idle(this);
        _rotateState = new RotateTo(this);
        _attackState = new Attack(this);
        _rocketLaunch = new RocketLaunch(this);

        stateMachine.StartState(_idleState);
    }

    public override void updateState()
    {
        if (dead) return;

        if (Vector3.Distance(turretTop.position, player.position) > DetectionRange)
            stateMachine?.SetState(_idleState);
        else if (Vector3.Angle(turretTop.forward, player.position - turretTop.position) > 0.5f)
            stateMachine?.SetState(_rotateState);
        else if (attackCount == rocketInterval)
            stateMachine?.SetState(_rocketLaunch);
        else
            stateMachine?.SetState(_attackState);

        stateMachine?.Update();
    }

    public override void rotateTo(Vector3 point)
    {
        Vector3 dir = point - turretTop.position;
        turretTop.rotation = Quaternion.RotateTowards(turretTop.rotation, Quaternion.LookRotation(dir), rotationSpeed / updatePerSecond);
    }

    public override void attack(bool state)
    {
        base.attack(state);

        tracerSystem.createTracer(firePoint.position, firePoint.forward);

        Shot();
        StartCoroutine(CoolDown());

        attackCount++;
    }

    public override void stop(bool state)
    {

    }

    public void Shot()
    {
        RaycastHit[] hits;

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        hits = Physics.RaycastAll(ray, 100f, player.gameObject.layer);

        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Health playerHP = player.GetComponent<Health>();

                if (playerHP != null)
                    playerHP.hpDecrease(Damage);
            }
        }
    }

    public override void RocketLaunch(bool state)
    {
        Instantiate(rocket, firePoint.position, Quaternion.LookRotation(firePoint.forward));

        attackCount = 0;

        stateMachine?.SetState(_idleState);
    }

    private IEnumerator CoolDown()
    {
        

        yield return new WaitForSeconds(1 / FireRate);
    }

    private void OnDrawGizmos()
    {
        if (!showGizmo) return;

        Gizmos.DrawWireSphere(turretTop.position, DetectionRange);
    }
}
