using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 targetOffset;

    [SerializeField] private float smoothness;

    private void FixedUpdate()
    {
        FollowCharacter();
    }

    private void FollowCharacter()
    {
        transform.position =
            Vector3.Lerp(transform.position, target.position + targetOffset, Time.deltaTime * smoothness);
    }
}