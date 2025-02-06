using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D m_rb;
    bool m_isGround;
    GameController m_gc;

    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround)
        {
            // Vector2.up = (0, 1) -> (0, 1) * 5 = (0, 5)
            m_rb.AddForce(Vector2.up * jumpForce);
            m_isGround = false;

            if (aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
    }

    // Phương thức bắt sự va chạm không xuyên qua nhau giữa 2 đối tượng 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    // Phương thức bắt sự va chạm có thể xuyên qua nhau giữa 2 đối tượng
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (aus && loseSound && !m_gc.IsGameOver())
            {
                aus.PlayOneShot(loseSound);
            }
            m_gc.SetGameOverState(true);

            Debug.Log("Player collised with the obstacle. Game over!");
        }
    }

    public void Jump()
    {
        if (!m_isGround) return;
        m_rb.AddForce(Vector2.up * jumpForce);
        m_isGround = false;

        if (aus && jumpSound)
        {
            aus.PlayOneShot(jumpSound);
        }
    }
}
