using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DashSkill : Skill
{   
    [Header("Dash Skill")]
    public bool dashUnlocked;
    [SerializeField] private UI_SkillTreeSlot dashUnlockButton;

    public override void UseSkill()
    {
        base.UseSkill();
    }

    protected override void Start()
    {
        base.Start();

        Debug.Log("Estoy entrando a esto");
        dashUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockDash);
    }

    private void UnlockDash()
    {   
        Debug.Log("Attemp to unlock dash");
        if(dashUnlockButton.unlocked)
        {   
            Debug.Log("Dash unlocked");
            dashUnlocked = true;
        }
    }
}
