using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : IState
{
    AbstractEnemy enemy;

    public RocketLaunch (AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.attack(false);
        enemy.RocketLaunch(true);
    }

    public void Exit()
    {
        enemy.RocketLaunch(false);
        enemy.attack(true);
    }

    public void Update()
    {

    }
}
