using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 3;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("太空人").transform;
    }

    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.x = Mathf.Clamp(tar.x, -3, 135);
        tar.z = -2;
        tar.y = Mathf.Clamp(tar.y, -1, 8);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}
