using UnityEngine;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        GameManager.Instance.OnGameWin += ShowMenu;
    }

    private void ShowMenu()
    {
        gameObject.SetActive(true);
    }
}
