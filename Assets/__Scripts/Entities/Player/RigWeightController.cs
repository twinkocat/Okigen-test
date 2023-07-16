using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigWeightController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Rig                _rig;
    [SerializeField] private TouchInput         _touchInput;
    [Space]
    [Range(0, 1)]
    [SerializeField] private float              _defaultWeight = 0f;
    [SerializeField] private float              _delay;

    private void Start()
    {
        if ( _rig != null ) 
            _rig.weight = _defaultWeight;
        else
            Debug.LogError("Rig component is not assigned!");

        if (_touchInput != null)
        {
            _touchInput.OnLayerMaskTargetTouch += RigWeightIncrease;
            _touchInput.OnLayerMaskTargetUntouch += RigWeightToDefault;
        }
        else
            Debug.LogError("TouchInput component is not assigned!");
    }

    private void RigWeightIncrease(Vector3 point)
    {
        _rig.weight = Mathf.MoveTowards(_rig.weight, 1f, _delay * Time.deltaTime);
    }

    private void RigWeightToDefault()
    {
        _rig.weight = Mathf.MoveTowards(_rig.weight, 0f, _delay * Time.deltaTime);
    }


    private void OnDestroy()
    {
        _touchInput.OnLayerMaskTargetTouch -= RigWeightIncrease;
        _touchInput.OnLayerMaskTargetUntouch -= RigWeightToDefault;
    }
}
