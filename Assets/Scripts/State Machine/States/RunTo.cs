public class RunTo : IState
{
    AbstractEnemy enemy;

    public RunTo(AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.stop(false);
        enemy.moveTo(enemy.Player.position);
    }

    public void Exit()
    {
        enemy.stop(true);
    }

    public void Update()
    {
        enemy.moveTo(enemy.Player.position);
    }
}