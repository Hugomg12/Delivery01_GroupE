using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void OnEnable()
    {
        Coin.OnCoinCollected += UpdateScore;
    }

    private void UpdateScore(int Score)
    {
        scoreText.text = "Score: " + Score;
    }

}
