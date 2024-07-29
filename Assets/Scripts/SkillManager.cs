using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    
    // ni esta lista tampoco , esto lo utilizo para lo de los consumibles , el metodo para las habilidades de combate es mejor como el la ense;a
    private HashSet<string> unlockedConsumiblesSkills = new HashSet<string>();

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
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
