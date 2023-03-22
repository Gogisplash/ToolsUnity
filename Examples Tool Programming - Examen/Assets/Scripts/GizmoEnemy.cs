using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoEnemy : MonoBehaviour
{
    [SerializeField] private EnemyScript Enemy;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Enemy.AttackRadius);

    }
}
