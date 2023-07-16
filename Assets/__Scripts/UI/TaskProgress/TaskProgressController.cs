using UnityEngine;

public class TaskProgressController : Controller
{
    [Header("Dependencies")]
    [SerializeField] private TaskProgressView       _view;


    private void Start()
    {
        GameManager.Instance.OnCollectedFoodValueChange += OnCollectedTasksFoodEventListener;
        SendDataToView();
    }

    protected override void SendDataToView()
    {
        _view.SetText
            (
                $"Progress: {GameManager.Instance.CurrentFoodCollected}/{GameManager.Instance.FoodValueForCompleteTask}"
            );
        _view.Display();
    }

    private void OnCollectedTasksFoodEventListener()
    {
        SendDataToView();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCollectedFoodValueChange -= OnCollectedTasksFoodEventListener;
    }
}
