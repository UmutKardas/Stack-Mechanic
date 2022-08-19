using UnityEngine;

public class CameraFallowController : MonoBehaviour
{

    [SerializeField] private Transform heroTransform;
    private Vector3 offset;
    [SerializeField] private float lerpValue;
    private Vector3 newPositionVector;



    void Start()
    {
        offset = transform.position - heroTransform.position;
    }



    void LateUpdate()
    {
        SetCameraFallow();
    }



    private void SetCameraFallow()
    {
        newPositionVector = Vector3.Lerp(transform.position, heroTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPositionVector;
    }
}
