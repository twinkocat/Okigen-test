using UnityEngine;

public class PointOfInterestPosController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform  _pointOfInterest;
    [Space]
    [SerializeField] private float      _lerpTime;


    private void Start()
    {
        TouchInput.Instance.OnLayerMaskTargetTouch += POIChangePosition;
    }

    private void POIChangePosition(Vector3 points)
    {
        
        _pointOfInterest.position = Vector3.Lerp(_pointOfInterest.position, points, _lerpTime * Time.deltaTime);
    }

    private void OnDestroy()
    {
        TouchInput.Instance.OnLayerMaskTargetTouch -= POIChangePosition;
    }
}
