using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<ItemFactory> itemFactories = new List<ItemFactory>();
    
    public void SpawnRandomItem()
    {
        ItemFactory itemFactory = itemFactories[Random.Range(0, itemFactories.Count)];
        IItem item = itemFactory.GetItem();

        Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        direction = direction.normalized * Random.Range(3, 6);
        Vector3 position = transform.position + direction;

        item.SetPosition(position);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SpawnRandomItem();
    }
}