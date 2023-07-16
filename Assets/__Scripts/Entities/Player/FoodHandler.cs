using System;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TouchInput             _touchInput;
    [SerializeField] private TrowInBucketScript     _trowInBucketScript;

    public event Action<Food>                       OnFoodHandled;
    public event Action                             OnCollectedTasksFood;


    private void Awake()
    {
        if (_trowInBucketScript != null )
            _trowInBucketScript.OnFoodTrowed += FoodUnhandle;
        else
            Debug.LogError("TrowInBucketScript component is not assigned!");

        if (_touchInput == null)
            Debug.LogError("TouchInput component is not assigned!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.childCount == 0)
        {
            if (other.gameObject.TryGetComponent<Food>(out Food obj))
            {
                _touchInput.TurnOffInput();
                FoodHandle(obj);
                OnFoodHandled?.Invoke(obj);
            }
        }
    }

    private void FoodHandle(Food obj)
    {
        obj.SetStateInHand(this.transform);
        
    }

    private void FoodUnhandle(Food obj)
    {
        if (obj.FoodName == GameManager.Instance.FoodForTask.FoodName)
            OnCollectedTasksFood?.Invoke();
        obj.SetStateUnhanded();
        _touchInput.TurnOnInput();
    }

    private void OnDestroy()
    {
        _trowInBucketScript.OnFoodTrowed -= FoodUnhandle;
    }
}
