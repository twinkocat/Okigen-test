using Redcode.Pools;
using System.Collections;
using UnityEngine;

public class FoodInSceneController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PoolManager            _poolManager;
    [SerializeField] private FoodDeadZoneTrigger    _foodDeadZoneTrigger;
    [Space]
    [Range(1, 10)]
    [SerializeField] private float                  _spawnDelay;

    private void Start()
    {
        _foodDeadZoneTrigger.OnTriggerZoneEnter += ReturnIntoPool;

        StartCoroutine(FoodSpawnMachine());
    }

    IEnumerator FoodSpawnMachine()
    {
        while(true)
        {
            SpawnFood();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    public void SpawnFood()
    {
        int rndNumber = Random.Range(0, GameManager.Instance.FoodList.Count);

        var pool = _poolManager.GetPool<Food>(rndNumber);
        var item = pool.Get();
        if (item == null)
        {
            pool.SetCount(pool.Count + 1);
            item = pool.Get();
        }

        item.transform.position = transform.position;
    }
    
    private void ReturnIntoPool(Food clone)
    {
        _poolManager.TakeToPool<Food>(clone.FoodName, clone);
    }

    private void OnDestroy()
    {
        _foodDeadZoneTrigger.OnTriggerZoneEnter -= ReturnIntoPool;
    }
}
