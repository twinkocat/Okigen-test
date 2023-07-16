using UnityEngine;

public class Conveirt : MonoBehaviour
{
    [SerializeField] private GameObject _conveyorLine;

    [SerializeField] private float  _conveyorSpeed = 1f;
    private Rigidbody               _rb;
    private Material                _mat;
    private const float             _conveyorAnimationOffset = 10f;


    private void Awake()
    {
        _mat = _conveyorLine.GetComponent<Renderer>().material;
        _rb = _conveyorLine.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameWin += SetDisabledConveyor;
    }

    private void FixedUpdate()
    {
        _mat.mainTextureOffset = new Vector2(Time.time * _conveyorSpeed * _conveyorAnimationOffset * Time.fixedDeltaTime, 0f);

        Vector3 pos = _rb.position;
        _rb.position += Vector3.left * _conveyorSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(pos);
    }

    private void SetDisabledConveyor()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameWin -= SetDisabledConveyor;
    }
}
