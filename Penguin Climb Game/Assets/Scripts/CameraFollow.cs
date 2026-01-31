using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Camera Movement")]
    public float smoothSpeed = 5f;
    public Vector3 offset;

    [Header("Auto Up Movement")]
    public float autoUpSpeed = 1.5f;   // kamera özü yuxarı qalxır

    void LateUpdate()
    {
        if (player == null) return;

        // Kameranın avtomatik yuxarı hərəkəti
        Vector3 autoMove = transform.position + Vector3.up * autoUpSpeed * Time.deltaTime;

        // Player-i izləmək üçün istənilən pozisiya
        Vector3 playerFollowPos = new Vector3(
            transform.position.x,
            player.position.y + offset.y,
            transform.position.z
        );

        // Hansı Y böyükdürsə onu götürürük
        float targetY = Mathf.Max(autoMove.y, playerFollowPos.y);

        Vector3 targetPosition = new Vector3(
            transform.position.x,
            targetY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
