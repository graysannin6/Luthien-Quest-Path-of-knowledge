using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skillTreeUI;
    [SerializeField] private GameObject craftUI; 
    [SerializeField] private GameObject optionsUI;

    [SerializeField] private ScrollRect craftScrollView;

    [SerializeField] private Button craftButton;

    [SerializeField] private GameObject warningMessage;



    
    public UI_ItemToolTip itemToolTip;
    public UI_SkillToolTip skillToolTip;
    public UI_CraftWindow craftWindow;

    [SerializeField] private string requiredCraftSkillName; // The name of the skill required to unlock the craft UI

    void Start()
    {
        SwitchTo(null);
       
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchWithKeyTo(characterUI);
            Debug.Log("Character UI");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchWithKeyTo(craftUI);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchWithKeyTo(skillTreeUI);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchWithKeyTo(optionsUI);
        }
        
        UnlockCraftUI();
        
    }

    public void SwitchTo(GameObject _menu)
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            return;
        }
        
        SwitchTo(_menu);
    }

    public void UnlockCraftUI()
    {
        if (!SkillManager.instance.IsSkillUnlocked(requiredCraftSkillName))
        {   
            

            craftScrollView.gameObject.SetActive(false);
            craftWindow.gameObject.SetActive(false);
            craftButton.gameObject.SetActive(false);
            warningMessage.gameObject.SetActive(true);
            

        }
        else
        {
            warningMessage.gameObject.SetActive(false);
            craftScrollView.gameObject.SetActive(true);
            craftWindow.gameObject.SetActive(true);
            craftButton.gameObject.SetActive(true);
        }
    }
}

