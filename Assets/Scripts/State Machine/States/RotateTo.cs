public class RotateTo : IState
{
    AbstractEnemy enemy;
    float updatesPerSecond;

    public RotateTo(AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.stop(true);
        updatesPerSecond = enemy.updatePerSecond;
        enemy.updatePerSecond = 60;
    }

    public void Exit()
    {
        enemy.stop(false);
        enemy.updatePerSecond = updatesPerSecond;
    }

    public void Update()
    {
        enemy.rotateTo(enemy.Player.position);
    }
}