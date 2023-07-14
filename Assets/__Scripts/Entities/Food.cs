using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private string _foodName;
    [SerializeField] private Sprite _foodSprite;

    private Rigidbody _rb;
    private Collider _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public string FoodName { get { return _foodName; } }
    public Sprite Sprite { get { return _foodSprite; } }
    public Rigidbody Rb { get { return _rb; } }
    public Collider Collider { get { return _collider; } }
}
