using UnityEngine;
using UnityEngine.Events;

public class PlatformsTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlatformTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Destroy(other.gameObject);
            onPlatformTriggered?.Invoke();
        }
    }
}
