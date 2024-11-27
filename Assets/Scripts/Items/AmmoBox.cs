using UnityEngine;

public class AmmoBox : MonoBehaviour, IItem
{
    [SerializeField] private WeaponTypes weaponType;
    [SerializeField, Range(1, 400)] private int ammoAmount = 40;

    public void OnPickUp(GameObject player)
    {
        if (player.GetComponent<Ammunition>().AddAmmo(weaponType, ammoAmount))
            Destroy(gameObject);
    }

    public void SetPosition(Vector3 position) => transform.position = position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnPickUp(other.gameObject);
    }
}
