using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void ResetGame()
    {
        Score = 0;
        SceneManager.LoadScene("Title");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Ending");
    }
}
