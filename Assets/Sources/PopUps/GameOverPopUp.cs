using System;
using TMPro;
using UnityEngine;

public sealed class GameOverPopUp : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    public Action OnCloseAction;

    public void Init(int score, out Boolean isPlaying)
    {
        ScoreText.text = "Score: " + score;
        isPlaying = false;
    }

    public void Restart()
    {
        OnCloseAction?.Invoke();
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}