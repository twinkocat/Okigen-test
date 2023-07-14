using System;
using UnityEngine;

public class FoodDeadZoneTrigger : MonoBehaviour
{
    public event Action<Food>       OnTriggerZoneEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Food>(out Food obj))
        {
            OnTriggerZoneEnter?.Invoke(obj);
        }
    }
}
