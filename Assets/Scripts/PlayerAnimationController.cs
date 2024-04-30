using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Transform enemyTarget;
    private bool isMovingToEnemy = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isMovingToEnemy && enemyTarget != null)
        {
            Vector3 moveDirection = enemyTarget.position - transform.position;
            moveDirection.y = 0f;

            if (moveDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }

            rb.MovePosition(rb.position + moveDirection.normalized * Time.deltaTime * 3);

            animator.SetFloat("Speed", moveDirection.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }


    public void MoveToEnemy(Transform enemyTransform)
    {
        enemyTarget = enemyTransform;
        isMovingToEnemy = true;
    }

    public void StopMoveToEnemy()
    {
        enemyTarget = null;
        isMovingToEnemy = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!collision.gameObject.GetComponent<Enemy>().isKilled)
            {
                StopMoveToEnemy();
            }
        }
    }
}
