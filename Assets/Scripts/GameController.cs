using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnTime;   // khoảng thời gian tạo thêm 1 obstacle

    float m_spawnTime;      // lưu trữ giá trị spawnTime
    int m_score;
    bool m_isGameOver;

    UIManager m_ui;

    public int GetScore()
    {
        return m_score;
    }
    public void SetScore(int value)
    {
        m_score = value;
    }

    public void ScoreIncrement()
    {
        if (m_isGameOver) return;
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public bool IsGameOver()
    {
        return (m_isGameOver);
    }

    public void SetGameOverState(bool state)
    {
        m_isGameOver = state; 
    }

    public void SpawnObstacle()
    {
        float randYPos = Random.Range(-2.75f, -0.1f);
        Vector2 spawnPos = new Vector2(14, randYPos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindAnyObjectByType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
