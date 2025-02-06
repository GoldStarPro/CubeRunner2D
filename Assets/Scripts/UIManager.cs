using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText) scoreText.text = txt;
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel) gameOverPanel.SetActive(isShow);
    }
}
