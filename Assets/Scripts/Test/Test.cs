using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject megaCube;
    //private GameObject gigaCube;
    /*public Test(params object[] items)
    {

    }
    public void Deconstruct()
    {

    }*/
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Instantiate(megaCube, new Vector3(k, j, i), Quaternion.identity);
                }
            }
        }
        /*for (int i1 = 0; i1 < 3; i1++)
        {
            for (int j1 = 0; j1 < 3; j1++)
            {
                for (int k1 = 0; k1 < 3; k1++)
                {
                    Instantiate(gigaCube, new Vector3(k1, j1, i1), Quaternion.identity);
                }
            }
        }*/
    }
}
