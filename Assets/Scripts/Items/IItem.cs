using UnityEngine;

public interface IItem
{
    public void OnPickUp(GameObject player);


    public void SetPosition(Vector3 position);
}