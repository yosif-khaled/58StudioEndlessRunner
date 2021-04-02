using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject controlPanel;
    private void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (gameOver == true)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            controlPanel.SetActive(false);
        }

    }
}
