using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Transform enemyTarget;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (!hit.transform.GetComponent<Enemy>().isKilled)
                    {
                        SetEnemyTarget(hit.transform);
                    }
                }
            }
        }
    }

    public void SetEnemyTarget(Transform enemyTransform)
    {
        enemyTarget = enemyTransform;
        GetComponent<PlayerAnimationController>().MoveToEnemy(enemyTarget);
    }
}
