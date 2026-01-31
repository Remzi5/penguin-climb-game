using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform cameraTransform;
    public float deathOffset = -6f;

    void Update()
    {
        if (transform.position.y < cameraTransform.position.y + deathOffset)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }
}
