public class Attack : IState
{
    AbstractEnemy enemy;

    public Attack(AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.stop(true);
        enemy.attack(true);
    }

    public void Exit()
    {
        enemy.stop(false);
        enemy.attack(false);
    }

    public void Update()
    {
        enemy.attack(true);
    }
}
