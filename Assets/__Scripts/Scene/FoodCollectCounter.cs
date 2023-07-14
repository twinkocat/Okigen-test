using System;
using UnityEngine;

public class FoodCollectCounter : MonoBehaviour
{
    public event Action   OnCollectedTasksFood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Food>(out Food obj))
        {
            if (obj.FoodName == GameManager.Instance.FoodForTask.FoodName)
                OnCollectedTasksFood?.Invoke();
        }
    }
}
