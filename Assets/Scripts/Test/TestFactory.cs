using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactory
{
    private TestPool testPool;
    private GameObject obj;

    public TestFactory()
    {
        testPool = MonoBehaviour.FindFirstObjectByType<TestPool>();
    }

    public GameObject CreateCube(Transform parent)
    {
        obj = testPool.GetPoolItem();
        obj.SetActive(true);
        obj.transform.SetParent(parent);
        return obj;
    }
    public void DeleteCube(GameObject obj)
    {
        testPool.ReturnToPool(obj);
    }
}
