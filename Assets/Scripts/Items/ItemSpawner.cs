using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemProbability> itemProbabilities = new List<ItemProbability>();
    private List<ItemFactory> itemFactories = new List<ItemFactory>();

    ItemFactory _itemFactory;

    public void SpawnRandomItem()
    {
        _itemFactory = itemFactories[Random.Range(0, itemFactories.Count)];
        IItem item = _itemFactory.GetItem();

        Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        direction = direction.normalized * Random.Range(3, 6);
        Vector3 position = transform.position + direction;

        item.SetPosition(position);
    }

    private void Start()
    {
        float probabilitySum = 0f;

        foreach (var item in itemProbabilities)
            probabilitySum += item.probability;

        foreach (var item in itemProbabilities)
            item.probability = Mathf.Floor((item.probability / probabilitySum) * 100);

        foreach (var item in itemProbabilities)
            for (int i = 0; i < item.probability; i++)
                itemFactories.Add(item.factory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SpawnRandomItem();
    }
}