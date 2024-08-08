using System.Collections.Generic;
using UnityEngine;

public class WizardAttackPool : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 1;

    void Awake()
    {
    }

    void Start()
    {
        Debug.Log("pooledObjects");
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(attackPrefab);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    private void Update()
    {
    }

    public GameObject GetPooled()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}