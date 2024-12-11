using UnityEngine;

public class RangeEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject _rangeEnemy;

    public override IEnemy GetEnemy()
    {
        GameObject enemy = Instantiate(_rangeEnemy);

        return enemy.GetComponent<RangeEnemy>();
    }
}
