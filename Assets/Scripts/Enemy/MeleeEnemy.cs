using UnityEngine;

public class MeleeEnemy : AbstractEnemy
{
    [Range(0.1f, 10)] public float AttackRange = 2f;
    [Range(1, 10)] public int Damage = 4;

    RunTo _runState;
    RotateTo _rotateState;
    Attack _attackState;
    Stunned _stunnedState;

    private new void Start()
    {
        base.Start();

        _runState = new RunTo(this);
        _rotateState = new RotateTo(this);
        _attackState = new Attack(this);
        _stunnedState = new Stunned(this);

        stateMachine.StartState(_runState);
    }

    public override void updateState()
    {
        if (dead) return;

        if (stunned) stateMachine?.SetState(_stunnedState);
        else
        {
            if (Vector3.Angle(transform.forward, player.position - transform.position) > 20f)
                stateMachine?.SetState(_rotateState);
            else if (Vector3.Distance(transform.position, player.position) > AttackRange)
                stateMachine?.SetState(_runState);
            //else if (Vector3.Angle(transform.forward, player.position - transform.position) > 10f)
            //    stateMachine?.SetState(_rotateState);
            else
                stateMachine?.SetState(_attackState);
        }

        Debug.Log(Vector3.Angle(transform.forward, player.position - transform.position));
        Debug.Log(player.position + " " + transform.position);
        Debug.Log(stateMachine.currentState);

        stateMachine?.Update();
    }

    public void DealDamage()
    {
        if (Vector3.Distance(transform.position, player.position) <= AttackRange)
        {
            Health playerHP = player.GetComponent<Health>();

            if (playerHP != null)
                playerHP.hpDecrease(Damage);
        }
    }
}