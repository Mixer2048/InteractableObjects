using UnityEngine;

public class Invincible : IState
{
    AbstractEnemy enemy;
    float shieldTime;
    float currentTime;

    public Invincible(AbstractEnemy enemy, float shieldTime)
    {
        this.enemy = enemy;
        this.shieldTime = shieldTime;

        currentTime = 0;
    }

    public void Enter()
    {
        enemy.shieldUp();
    }

    public void Exit()
    {
        //enemy.shieldDown();
    }

    public void Update()
    {
        if (currentTime < shieldTime)
            currentTime += Time.deltaTime;
        else
        {
            enemy.shieldDown();
            currentTime = 0;
        }
            
    }
}
