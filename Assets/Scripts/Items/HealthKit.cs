using UnityEngine;

public class HealthKit : MonoBehaviour, IItem
{
    [SerializeField, Range(1, 100)] int healthRegenAmount = 20;
    
    public void OnPickUp(GameObject player)
    {
        if (player.GetComponent<Health>().ChangeHealth(healthRegenAmount))
            Destroy(gameObject);
    }

    public void SetPosition(Vector3 position) => transform.position = position;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
            OnPickUp(other.gameObject);
    }
}
