using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactoryMono //: MonoBehaviour
{
    public void CreateCube(CubeType type)
    {
        switch (type)
        {
            case CubeType.Default:
                MonoBehaviour.print("Default cube created");
                break;
            case CubeType.Mega:
                MonoBehaviour.print("Mega cube created");
                break;
            case CubeType.Giga:
                MonoBehaviour.print("Giga cube created");
                break;
            case CubeType.Black:
                MonoBehaviour.print("Black cube created");
                break;
            case CubeType.MyCube:
                MonoBehaviour.print("My cube created");
                break;
        }
    }
}

public enum CubeType
{
    Default,
    Mega,
    Giga,
    Black,
    MyCube
}
