using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    private float maxHeight;

    void Update()
    {
        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
        }

        scoreText.text = "Score: " + Mathf.FloorToInt(maxHeight).ToString();
    }
}
