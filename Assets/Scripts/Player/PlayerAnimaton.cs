using UnityEngine;

public class PlayerAnimaton : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDie()
    {
        _animator.SetTrigger("Dead");
    }

    public void PlayHit()
    {
        _animator.SetTrigger("Damaged");
    }
}
