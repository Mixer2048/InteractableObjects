using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField, Range(0f, 15f)] private float _upDistance = 10f;
    [SerializeField, Range(0f, 15f)] private float _backDistance = 4f;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = _player.position + Vector3.up * _upDistance + Vector3.back * _backDistance;
    }
}