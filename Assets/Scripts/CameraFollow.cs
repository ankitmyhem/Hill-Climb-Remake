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
        speed = CarController.instance.speed;
        CameraSize();
        CameraOffset();
    }

    void CameraOffset()
    {
        //following the car with offset
        customOffset = new Vector3(offset.x + speed.x / 2, offset.y, offset.z);
        targetPos = followPlayer.position + customOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    void CameraSize()
    {
        //Controlling the orthographic size of camera
        // speeding up will increase the orthographic size
        targetSize = cameraSize + Mathf.Abs(speed.magnitude)/6;

        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, targetSize, ref changeSizeSpeed, 0.5f);
    }
}
