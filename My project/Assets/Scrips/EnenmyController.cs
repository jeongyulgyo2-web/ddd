using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
   

    private Rigidbody2D rb;
    private bool isMoveingRight = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isMoveingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed,rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMoveingRight = !isMoveingRight;
        }
    }
}
