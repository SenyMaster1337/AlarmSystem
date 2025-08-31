using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class House : MonoBehaviour
{
    public event Action HouseEntered;
    public event Action HouseLefted;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            HouseEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Crook human))
        {
            HouseLefted?.Invoke();
        }
    }
}
