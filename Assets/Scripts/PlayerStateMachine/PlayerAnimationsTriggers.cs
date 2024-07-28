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
}
