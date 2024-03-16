using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestPool : MonoBehaviour
{
    [SerializeField] private Transform poolParent;
    [SerializeField] private GameObject cubePb;
    [SerializeField] private List<GameObject> cubePool = new();
    private int startPoolCount;

    private void Awake()
    {
        GeneratePool(startPoolCount);
    }

    private void GeneratePool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(cubePb, poolParent);
            temp.SetActive(false);
            cubePool.Add(temp);
        }
    }

    public GameObject GetPoolItem()
    {
        if (cubePool.Count > 0)
        {
            GameObject temp = cubePool.FirstOrDefault();
            cubePool.Remove(temp);
            return temp;
        }
        return AddItemToPool();
    }

    public GameObject AddItemToPool()
    {
        GameObject temp = Instantiate(cubePb, poolParent);
        temp.SetActive(false);
        return temp;
    }

    public void ReturnToPool(GameObject obj)
    {
        cubePool.Add(obj);
        obj.transform.SetParent(transform);
        obj.SetActive(false);
    }
}
