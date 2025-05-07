using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 플레이어
    public Vector3 offset = new Vector3(0, 0, -10f);
    public float smoothSpeed = 5f;

    // 경계 설정
    public Vector2 minBounds;  // 카메라가 움직일 수 있는 최소 위치 (좌하단)
    public Vector2 maxBounds;  // 카메라가 움직일 수 있는 최대 위치 (우상단)

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // 경계 안으로 카메라 위치 제한
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
    }
}