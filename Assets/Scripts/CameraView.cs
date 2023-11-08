using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Vector3 offset;
    [Header("Target")] //Header for Target
    public Transform target;
    [Header("Distances")] //Header for Distance
    [Range(2f,10f)]public float distance = 5f;
    public float minDistance = 1f;
    public float maxDistance = 10f;
    [Header("Speeds")] //Header for Speeds
    public float smoothTime = 5f;
    public float scrollSensitivity = 10f;

    private void Start()
    {

    }
    //XXX comment by @linkft: we should just use cinemachine framing transposer instead, and change the distance value of virtual camera with mouse wheel
    void LateUpdate()
    {
        if (!target)
        {
            print("No target set");
            return;
        }

        float num = Input.GetAxis("Mouse ScrollWheel");
        distance -= num * scrollSensitivity;
        distance = Mathf.Clamp(distance, minDistance, 10f);

        Vector3 pos = target.position + offset;
        pos -= transform.forward * distance;

        transform.position = Vector3.Lerp(transform.position, pos, smoothTime * Time.deltaTime);
    }
}
