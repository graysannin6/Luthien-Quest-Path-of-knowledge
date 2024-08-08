using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int currency;
    
    public SerializableDictionary<string, int> inventory;

    public GameData()
    {
        currency = 0;
        inventory = new SerializableDictionary<string, int>();
    }
}
