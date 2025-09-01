using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Trigger : MonoBehaviour
{
    public event Action Entered;
    public event Action Lefted;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            Entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            Lefted?.Invoke();
        }
    }
}
