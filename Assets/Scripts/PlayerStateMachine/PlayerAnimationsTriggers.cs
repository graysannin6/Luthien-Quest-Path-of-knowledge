using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsTriggers : MonoBehaviour
{

    private Player player => GetComponentInParent<Player>();

    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            hit.GetComponent<Enemy>()?.Damage();
        }
    }
}
