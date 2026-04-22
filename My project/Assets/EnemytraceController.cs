using UnityEngine;

public class EnemytraceController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float raycastDistance = 2f;
    public float traceDistance = 2f;

    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        if(direction.magnitude > traceDistance)
        {
            return;
        }
        Vector2 directionNormalLized = direction.normalized;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNormalLized,raycastDistance);
        Debug.DrawRay(transform.position, directionNormalLized * raycastDistance, Color.red);
        foreach(RaycastHit2D rHit in hits)
        {
            if (rHit.collider != null && rHit.collider.CompareTag("Obstacle"))
            { 
                Vector3 alternativeDriection = Quaternion.Euler(0f, 0f, -90f) * direction;
                transform.Translate(alternativeDriection*moveSpeed*Time.deltaTime);
            }
            else
            {
                transform.Translate(directionNormalLized * moveSpeed*Time.deltaTime);
            }
        }
    }
}
