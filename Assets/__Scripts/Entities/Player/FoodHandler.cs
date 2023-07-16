using System;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TrowInBucketScript    _trowInBucketScript;

    public event Action<Food>                       OnFoodHandled;


    private void Awake()
    {
        if (_trowInBucketScript != null )
            _trowInBucketScript.OnFoodTrowed += FoodUnhandle;
        else
            Debug.LogError("TrowInBucketScript component is not assigned!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.childCount == 0)
        {
            if (other.gameObject.TryGetComponent<Food>(out Food obj))
            {
                TouchInput.Instance.TurnOffInput();
                FoodHandle(obj);
                OnFoodHandled?.Invoke(obj);
            }
        }
    }

    private void FoodHandle(Food obj)
    {
        obj.transform.SetParent(this.transform);
        obj.Rb.isKinematic = true;
        obj.Collider.enabled = false;
        obj.transform.position = transform.position;
    }

    private void FoodUnhandle(Food obj)
    {
        obj.transform.SetParent(null);
        obj.Rb.isKinematic = false;
        obj.Collider.enabled = true;
        obj.transform.localScale *= 0.66f;

        TouchInput.Instance.TurnOnInput();
    }

    private void OnDestroy()
    {
        _trowInBucketScript.OnFoodTrowed -= FoodUnhandle;
    }
}
