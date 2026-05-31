using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // give access 
    private bool gameOver;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        if (gameOver)
            return;
        gameOver = true;
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}