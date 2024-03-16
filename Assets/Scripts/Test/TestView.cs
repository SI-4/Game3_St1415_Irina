using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestView : MonoBehaviour
{
    //[SerializeField] private Button defaultCube;
    //[SerializeField] private Button megaCube;
    //[SerializeField] private Button gigaCube;
    //[SerializeField] private Button blackCube;
    //[SerializeField] private Button myCube;

    [Inject] TestFactoryMono testFactory;

    void Start()
    {
        testFactory.CreateCube(CubeType.Default);

        //testFactory = FindAnyObjectByType<TestFactoryMono>();
        //defaultCube.onClick.AddListener(() => testFactory.CreateCube(CubeType.Default));
        //megaCube.onClick.AddListener(() => testFactory.CreateCube(CubeType.Mega));
        //gigaCube.onClick.AddListener(() => testFactory.CreateCube(CubeType.Giga));
        //blackCube.onClick.AddListener(() => testFactory.CreateCube(CubeType.Black));
        //myCube.onClick.AddListener(() => testFactory.CreateCube(CubeType.MyCube));

        //TestFactory factory = new TestFactory();
        //GameObject cube = factory.CreateCube(transform);
        //factory.DeleteCube(cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
