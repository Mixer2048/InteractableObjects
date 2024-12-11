using UnityEngine;

public class ScriptLocker : MonoBehaviour
{
    public void LockScripts()
    {
        foreach (var component in transform.GetComponents<MonoBehaviour>())
            if (component != this)
                component.enabled = false;
    }

    public void UnlockScripts()
    {
        foreach (var component in transform.GetComponents<MonoBehaviour>())
            if (component != this)
                component.enabled = true;
    }

}