using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private string _foodName;
    [SerializeField] private Sprite _foodSprite;

    public string FoodName => _foodName;
    public Sprite Sprite => _foodSprite;

    private Rigidbody _rb;
    private Collider _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public bool IsKinematic()
    {
        return _rb.isKinematic;
    }

    public void SetStateUnhanded()
    {
        transform.SetParent(null);
        _rb.isKinematic = false;
        _collider.enabled = true;
        transform.localScale *= 0.66f;
    }

    public void SetStateInHand(Transform hand)
    {
        transform.SetParent(hand);
        _rb.isKinematic = true;
        _collider.enabled = false;
        transform.position = transform.position;
    }

    public void SetStateInBucket(Transform bucket)
    {
        transform.SetParent(bucket);
        _rb.isKinematic = true;
        _collider.enabled = false;
    }
}
