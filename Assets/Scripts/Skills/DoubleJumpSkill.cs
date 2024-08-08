using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJumpSkill : Skill
{
    [Header("Double Jump Skill")]
    public bool doubleJumpUnlocked;
    [SerializeField] private UI_SkillTreeSlot doubleJumpUnlockButton;

    public override void UseSkill()
    {
        base.UseSkill();
    }

    protected override void Start()
    {
        base.Start();

        
        doubleJumpUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockDoubleJump);
    }

    private void UnlockDoubleJump()
    {
        //if (doubleJumpUnlockButton.unlocked)
        //{
        doubleJumpUnlocked = true;
        //}
    }
}
