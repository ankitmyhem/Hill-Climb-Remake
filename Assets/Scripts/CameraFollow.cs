using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followPlayer;
    public Vector3 offset;
    private Vector3 customOffset;
    public float followSpeed;
    private Vector3 targetPos;
    private Vector3 speed;
    private float cameraSize;
    private float targetSize;
    private float changeSizeSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.FindObjectOfType<CarController>().speed;
        CameraSize();
        CameraOffset();
    }

    void CameraOffset()
    {
        customOffset = new Vector3(offset.x + speed.x / 2, offset.y, offset.z);
        targetPos = followPlayer.position + customOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    void CameraSize()
    {
        targetSize = cameraSize + Mathf.Abs(speed.magnitude)/6;

        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, targetSize, ref changeSizeSpeed, 0.5f);
    }
}
