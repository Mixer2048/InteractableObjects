public class Stunned : IState
{
    AbstractEnemy enemy;

    public Stunned(AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.stop(true);
    }

    public void Exit()
    {
        enemy.stop(false);
    }

    public void Update()
    {

    }
}