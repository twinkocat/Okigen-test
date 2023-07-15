using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private FoodCollectCounter _counter;
    [Space]
    [SerializeField] private int _maxFoodValueForCompleteTask;
    [Space]
    [SerializeField] private List<Food> _foodList = new List<Food>();

    private Food                _randomFoodForTask;
    private int                 _randomFoodValueForCompleteTask;
    private int                 _currentFoodCollected;

    public static GameManager   Instance;

    public Action<Food>         OnRandomFoodSelected;
    public Action<int>          OnRandomFoodCountSelected;
    public Action               OnCollectedFoodValueChange;
    public Action               OnGameWin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (_counter != null)
            _counter.OnCollectedTasksFood += OnCollectedTasksFoodEventListener;
        else
            Debug.LogError("FoodCollectCounter not found!");

        _randomFoodForTask = GetRandomFoodForCompleteTask();
        _randomFoodValueForCompleteTask = GetRandomValueForCompleteTask(1, _maxFoodValueForCompleteTask);

        Application.targetFrameRate = 60;
    }

    private void OnCollectedTasksFoodEventListener()
    {
        if (_currentFoodCollected + 1 < _randomFoodValueForCompleteTask)
        {
            _currentFoodCollected++;
            OnCollectedFoodValueChange?.Invoke();
        } 
        else if (_currentFoodCollected + 1 == _randomFoodValueForCompleteTask)
        {
            _currentFoodCollected++;
            OnCollectedFoodValueChange?.Invoke();
            OnGameWin?.Invoke();
        }
        else
        {
            _currentFoodCollected = _maxFoodValueForCompleteTask;
            Debug.LogError("Something went wrong");
        }

    }

    private Food GetRandomFoodForCompleteTask()
    {
        int rndNum = Random.Range(0, _foodList.Count);
        return _foodList[rndNum];
    }

    private int GetRandomValueForCompleteTask(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    public Food FoodForTask { get { return _randomFoodForTask; } }
    public int FoodValueForCompleteTask { get { return _randomFoodValueForCompleteTask; } }
    public List<Food> FoodList { get { return _foodList; } }
    public int CurrentFoodCollected { get { return _currentFoodCollected; } }
}
