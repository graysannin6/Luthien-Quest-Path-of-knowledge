 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public DashSkill dash { get; private set; }
    public PotionThrowSkill throwSkill { get; private set; }

    // ni esta lista tampoco , esto lo utilizo para lo de los consumibles , el metodo para las habilidades de combate es mejor como el la ense;a
    private HashSet<string> unlockedConsumiblesSkills = new HashSet<string>();

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        dash = GetComponent<DashSkill>();
        throwSkill = GetComponent<PotionThrowSkill>();
    }

    // Christian Haz como que esto no existe
    public void UnlockSkill(string skillName)
    {
        if (!unlockedConsumiblesSkills.Contains(skillName))
        {
            unlockedConsumiblesSkills.Add(skillName);
        }
        else
        {

        }
    }
    public bool IsSkillUnlocked(string skillName)
    {
        bool isUnlocked = unlockedConsumiblesSkills.Contains(skillName);
        return isUnlocked;
    }
}
