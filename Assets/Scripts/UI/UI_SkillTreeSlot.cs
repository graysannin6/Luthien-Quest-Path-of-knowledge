using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillTreeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   
    private UI ui;
    private Image skillImage;
    [SerializeField] private string skillName;

    [TextArea]	
    [SerializeField] private string skillDescription;
    [SerializeField] private Color lockedSkillColor;
    public bool unlocked;

    [SerializeField] private UI_SkillTreeSlot[] shouldBeUnlocked;
    [SerializeField] private UI_SkillTreeSlot[] shouldBeLocked;

    

    private void OnValidate()
    {
        gameObject.name = "SkillTreeSlot_UI - " + skillName;

    }

    void Start()
    {
        skillImage = GetComponent<Image>();
        ui = GetComponentInParent<UI>();
        skillImage.color = lockedSkillColor;
        GetComponent<Button>().onClick.AddListener(() => UnlockSkillSlot());
    }

    public void UnlockSkillSlot()
    {
        for (int i = 0; i < shouldBeUnlocked.Length; i++)
        {
            if(shouldBeUnlocked[i].unlocked == false)
            {
                Debug.Log("Cannot unlock skill");
                return;
            }
        }

        for (int i = 0; i < shouldBeLocked.Length; i++)
        {
            if(shouldBeLocked[i].unlocked == true)
            {
                Debug.Log("Cannot unlock skill");
                return;
            }
        }

        unlocked = true;
        skillImage.color = Color.white;
        
        SkillManager.instance.UnlockSkill(skillName);
        
        
    }      
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.skillToolTip.ShowToolTip(skillDescription,skillName);

        Vector2 mousePosition = Input.mousePosition;

        float xOffSet = 0;
        if(mousePosition.x > 600)
        {
            xOffSet = -150;
        }
        else
        {
            xOffSet = 150;
        }

        ui.skillToolTip.transform.position = new Vector2(mousePosition.x + xOffSet, mousePosition.y + 150);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.skillToolTip.HideToolTip();
    }
}
