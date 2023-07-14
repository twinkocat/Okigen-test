using Redcode.Pools;
using System;
using System.Collections;
using UnityEngine;


public class FloatingText : MonoBehaviour, IPoolObject
{
    [SerializeField] private float _floatingTimeDuration;
    [SerializeField] private float _floatingSpeed;
    private float _floatingTime;

    public event Action<FloatingText>             OnTextFloatingEnd;

    public void OnCreatedInPool()
    {
        _floatingTime = 0;
    }

    public void OnGettingFromPool()
    {
        _floatingTime = 0;
        StartCoroutine(FloatingTextCoro());
    }

    IEnumerator FloatingTextCoro()
    {
        while (_floatingTime < _floatingTimeDuration)
        {
            transform.position += Vector3.up * _floatingSpeed * Time.deltaTime;
            _floatingTime += Time.deltaTime;
            yield return null;
        }
        OnTextFloatingEnd?.Invoke(this);
    }
}
