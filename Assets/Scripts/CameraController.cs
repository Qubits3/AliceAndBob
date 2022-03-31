using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private Vector3 targetOffset;

    [SerializeField] private float smoothness;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        FollowCharacter();
    }

    private void FollowCharacter()
    {
        transform.position =
            Vector3.Lerp(transform.position, _target.position + targetOffset, Time.deltaTime * smoothness);
    }
}