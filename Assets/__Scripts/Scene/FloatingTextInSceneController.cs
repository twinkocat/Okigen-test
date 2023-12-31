using Redcode.Pools;
using UnityEngine;

public class FloatingTextInSceneController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private FoodHandler            _foodHandler;
    [SerializeField] private PoolManager            _poolManager; 
    [SerializeField] private FloatingText           _floatingText;

    private void Start()
    {
        _foodHandler.OnCollectedTasksFood += SpawnText;
    }

    private void SpawnText()
    {
        var pool = _poolManager.GetPool<FloatingText>();
        var item = pool.Get();
        if (item != null)
        {
            item.OnTextFloatingEnd += ReturnToPool;
            item.transform.position = transform.position;
        }
    }

    private void ReturnToPool(FloatingText text)
    {
        text.OnTextFloatingEnd -= ReturnToPool;
        _poolManager.TakeToPool<FloatingText>(text);
    }
}
