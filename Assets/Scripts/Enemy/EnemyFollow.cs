using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 1.5f;
    public float stopDistance = 1.2f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 6f;

    private Transform player;
    private Animator animator;

    void Start()
    {
        Player_Tags playerComponent = Object.FindFirstObjectByType<Player_Tags>();

        if (playerComponent != null)
        {
            player = playerComponent.transform;
        }
        else
        {
            Debug.LogError("EnemyFollow: Could not find an object with the 'Player_Tags' script");
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;

        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            //if (animator != null)
            //    animator.SetBool("IsRunning", true);
        }
        else
        {
            //if (animator != null)
            //    animator.SetBool("IsRunning", false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
}