using UnityEngine;

public class PointOfInterestPosController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform  _pointOfInterest;
    [SerializeField] private TouchInput _touchInput;
    [Space]
    [SerializeField] private float      _lerpTime;

    private void Awake()
    {
        if (_touchInput == null)
            Debug.LogError("TouchInput component is not assigned!");
    }
    private void Start()
    {
        _touchInput.OnLayerMaskTargetTouch += POIChangePosition;
    }

    private void POIChangePosition(Vector3 points)
    {
        
        _pointOfInterest.position = Vector3.Lerp(_pointOfInterest.position, points, _lerpTime * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _touchInput.OnLayerMaskTargetTouch -= POIChangePosition;
    }
}
