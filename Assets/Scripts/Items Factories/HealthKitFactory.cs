using UnityEngine;

public class HealthKitFactory : ItemFactory
{
    [SerializeField] GameObject healthKitPrefab;

    public override IItem GetItem()
    {
        GameObject healthKit = Instantiate(healthKitPrefab);

        return healthKit.GetComponent<HealthKit>();
    }
}