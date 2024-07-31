using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrowSkill : Skill
{
    [Header("Skill info")]
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float potionGravity;


    private Vector2 finalDir;

    [Header("Aim dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    [Header("Potion Throw Skill")]

    public bool throwSkillUnlocked;
    [SerializeField] private UI_SkillTreeSlot throwSkillUnlockButton;

    private GameObject[] dots;

    protected override void Start()
    {
        base.Start();

        throwSkillUnlockButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(UnlockThrowSkill);
        GenerateDots();
    }

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
            finalDir = new Vector2(AimDirection().normalized.x * launchForce.x, AimDirection().normalized.y * launchForce.y);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = DotsPosition(i * spaceBetweenDots);
            }
        }

    }

    public void CreatePotion()
    {
        GameObject newPotion = Instantiate(potionPrefab, player.handPosition.position, transform.rotation);
        PotionSkillController newPotionScript = newPotion.GetComponent<PotionSkillController>();

        newPotionScript.SetupPotion(finalDir, potionGravity);

        DotsActive(false);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }

    public void DotsActive(bool _isActive)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(_isActive);
        }
    }

    private void GenerateDots()
    {
        dots = new GameObject[numberOfDots];

        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.handPosition.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosition(float t)
    {
        Vector2 position = (Vector2)player.handPosition.position + new Vector2(
            AimDirection().normalized.x * launchForce.x,
             AimDirection().normalized.y * launchForce.y) * t + .5f * (Physics2D.gravity * potionGravity) * (t * t);

        return position;
    }

    public void UnlockThrowSkill()
    {
        throwSkillUnlocked = true;
    }


}
