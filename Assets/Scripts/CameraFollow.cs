
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject car;

    public float smoothSpeed = 0.3f;
    public Vector3 offset;  
    void Start()
    {
        car = GameObject.Find("Car");
    }

    void LateUpdate()
    {
        Vector3 desiredPos = car.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(car.transform.position);
    }
}
