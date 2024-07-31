using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ParrySkill : Skill
{
    [Header("Parry Skill")]
    public bool parryUnlocked;
    [SerializeField] private UI_SkillTreeSlot parryUnlockButton;

    public override void UseSkill()
    {
        base.UseSkill();
    }

    protected override void Start()
    {
        base.Start();

        Debug.Log("Estoy entrando a esto");
        parryUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParry);
    }

    private void UnlockParry()
    {
        //if (parryUnlockButton.unlocked)
        //{
        parryUnlocked = true;
        //}
    }
}