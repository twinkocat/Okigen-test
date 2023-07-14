using UnityEngine;

public class TaskProgressController : Controller
{
    [Header("Dependencies")]
    [SerializeField] private TaskProgressView       _view;
    [SerializeField] private FoodCollectCounter     _counter;

    private int                                     _currentFoodCollected;

    private void Awake()
    {
        if (_counter != null)
            _counter.OnCollectedTasksFood += OnCollectedTasksFoodEventListener;
        else
            Debug.LogError("FoodCollectCounter not found!");
    }

    private void Start()
    {
        SendDataToView();
    }

    protected override void SendDataToView()
    {
        _view.DisplayText
            (
                $"Progress: {_currentFoodCollected}/{GameManager.Instance.FoodValueForCompleteTask}"
            );
    }

    private void OnCollectedTasksFoodEventListener()
    {
        _currentFoodCollected++;
        SendDataToView();
    }

    private void OnDestroy()
    {
        _counter.OnCollectedTasksFood -= OnCollectedTasksFoodEventListener;
    }
}
