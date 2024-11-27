using UnityEngine;

public class MeleeEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject _meleeEnemy;

    public override IEnemy GetEnemy()
    {
        GameObject enemy = Instantiate(_meleeEnemy);

        return enemy.GetComponent<MeleeEnemy>();
    }
}