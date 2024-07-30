using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsControl : MonoBehaviour
{
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerStats)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }
    }

    public void IncreaseHP(int value)
    {
        if ((playerStats.health + value) < 0)
        {
            return;
        }

        playerStats.health += value;

        if (playerStats.health > playerStats.MaxHP)
        {
        playerStats.health = playerStats.MaxHP;
        }
    }

    public void IncreaseMP(int value)
    {
        if ((playerStats.mana + value) < 0)
        {
            return;
        }

        playerStats.mana += value;

        if (playerStats.mana > playerStats.MaxMP)
        {
        playerStats.mana = playerStats.MaxMP;
        }
    }

    public void DecreaseMaxHP(int value)
    {
        if (playerStats.MaxHP + value < Mathf.Abs(value))
        {
            return;
        }

        playerStats.MaxHP += value;
    }

    public void DecreaseMaxMP(int value)
    {
        if (playerStats.MaxMP + value < Mathf.Abs(value))
        {
            return;
        }

        playerStats.MaxMP += value;
    }
}
