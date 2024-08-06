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

    [SerializeField] private GameObject inGame_UI;
    [SerializeField] private GameObject healthbar;



    public UI_ItemToolTip itemToolTip;
    public UI_SkillToolTip skillToolTip;
    public UI_CraftWindow craftWindow;

    [SerializeField] private string requiredCraftSkillName; // The name of the skill required to unlock the craft UI

    void Start()
    {

        SwitchTo(inGame_UI);
        itemToolTip.gameObject.SetActive(false);



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            healthbar.SetActive(true);
            SwitchWithKeyTo(characterUI);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            healthbar.SetActive(true);
            SwitchWithKeyTo(craftUI);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            healthbar.SetActive(true);
            SwitchWithKeyTo(skillTreeUI);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            healthbar.SetActive(true);
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

        healthbar.SetActive(true);

    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            // UnPause();
        }
        else
        {
            SwitchTo(_menu);
            //Pause();
        }
        healthbar.SetActive(true);
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

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }


}

