using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float deathY = -15f;
    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        if (transform.position.y < deathY)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Time.timeScale = 0f;
        GameOverManager.instance.GameOver();
    }
}
