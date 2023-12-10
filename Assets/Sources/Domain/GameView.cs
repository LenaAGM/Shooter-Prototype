using TMPro;
using UnityEngine;

public sealed class GameView : MonoBehaviour
{
    public GenerateObjectsManager GenerateObjectsManager;

    public Transform RightFrontier;
    public Transform LeftFrontier;

    public TextMeshProUGUI ScoreText;

    public PlayerHealthProgressBar PlayerHealthProgressBar;

    public PlayerController PlayerController;

    public GameOverPopUp GameOverPopUp;

    public void RefreshUI()
    {
        PlayerHealthProgressBar.Value = PlayerController.PlayerData.Health;
        ScoreText.text = PlayerController.PlayerData.Score + "";
    }
}