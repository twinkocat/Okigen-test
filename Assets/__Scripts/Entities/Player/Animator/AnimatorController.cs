using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TrowInBucketScript         _trowInBucketScript;
    [Space]
    [SerializeField] private string                     _putInBucketTriggerName = "PutInBucket"; //defaultName

    private Animator                                    _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();

        if (_trowInBucketScript != null )
            _trowInBucketScript.OnFoodCached += PlayPutInBucketAnimation;
        
    }

    private void PlayPutInBucketAnimation()
    {
        _animator.SetTrigger(_putInBucketTriggerName);
    }


    private void OnDestroy()
    {
        if (_trowInBucketScript != null)
            _trowInBucketScript.OnFoodCached -= PlayPutInBucketAnimation;
    }


}
