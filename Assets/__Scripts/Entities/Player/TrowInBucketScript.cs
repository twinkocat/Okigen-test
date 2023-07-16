using System;
using System.Collections;
using UnityEngine;


public class TrowInBucketScript : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AnimatorActionHandler  _animatorActionHandler;
    [Space]
    [SerializeField] private GameObject             _bucketHandler;
    [SerializeField] private FoodHandler            _foodHandler;
    [SerializeField] private GameObject             _foodCatcher;
    [Space]
    [Range(0, 1)]
    [SerializeField] private float                  _delayToStayInactiveInBucket;
    [Range(0, 10)]
    [SerializeField] private float                  _transitionTime;
    private Food                                    _handledFood;

    public event Action                             OnFoodCached;
    public event Action<Food>                       OnFoodTrowed;

    //private Food _handledFood;

    private void Start()
    {
        if (_foodHandler != null)
            _foodHandler.OnFoodHandled += SaveFoodInCache;
        else
            Debug.LogError("FoodHandler component is not assigned!");

        if (_animatorActionHandler != null)
            _animatorActionHandler.OnTrowingAnimationAction += TrowInBucket;
        else
            Debug.LogError("AnimatorActionHandler component is not assigned!");

    }

    public void TrowInBucket()
    {
        StartCoroutine(FoodTransitionCoro());
    }

    IEnumerator FoodTransitionCoro()
    {
        while(Vector3.Distance(_handledFood.transform.position, _foodCatcher.transform.position) > 0.01f)
        {
            _handledFood.transform.position = Vector3.MoveTowards(_handledFood.transform.position, _foodCatcher.transform.position, _transitionTime * Time.deltaTime);
            yield return null;
        }
        OnFoodTrowed?.Invoke(_handledFood);
        StartCoroutine(FoodStayIsKinematicDelay());
    }

    IEnumerator FoodStayIsKinematicDelay()
    {
        while(!_handledFood.Rb.isKinematic)
        {
            yield return new WaitForSeconds(_delayToStayInactiveInBucket);
            _handledFood.Rb.isKinematic = true;
            _handledFood.Collider.enabled = false;
            _handledFood.transform.SetParent(_bucketHandler.transform);
        }
    }

    private void SaveFoodInCache(Food obj)
    {
        _handledFood = obj;
        OnFoodCached?.Invoke();
    }

    private void OnDestroy()
    {
        if (_foodHandler != null)
            _foodHandler.OnFoodHandled -= SaveFoodInCache;

        if (_animatorActionHandler != null)
            _animatorActionHandler.OnTrowingAnimationAction -= TrowInBucket;
    }

}
