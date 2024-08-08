using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizardAnimationTrigger : MonoBehaviour
{
    private Enemy_Wizardo enemy => GetComponentInParent<Enemy_Wizardo>();

    private void Attack() => enemy.Attack();
}