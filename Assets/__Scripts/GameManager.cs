using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    [SerializeField] private int _maxFoodValueForCompleteTask;
    [Space]
    [SerializeField] private List<Food> _foodList = new List<Food>();


    private Food                _randomFoodForTask;
    private int                 _randomFoodValueForCompleteTask;


    public static GameManager   Instance;

    public Action<Food>         OnRandomFoodSelected;
    public Action<int>          OnRandomFoodCountSelected;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _randomFoodForTask = GetRandomFoodForCompleteTask();
        _randomFoodValueForCompleteTask = GetRandomValueForCompleteTask(1, _maxFoodValueForCompleteTask);

        Application.targetFrameRate = 60;
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
}
