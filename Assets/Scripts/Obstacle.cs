using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    GameController m_gc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.left = (-1, 0, 0) -> (-1, 0, 0) * 5 = (-5, 0, 0)
        transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneLimit"))
        {
            m_gc.ScoreIncrement();
            Debug.Log("Increase 1 point!");
            Destroy(gameObject);
            // Destroy nên để cuối cùng
        }
    }
}
