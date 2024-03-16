using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    public static WindowsManager layout;
    [SerializeField] private List<GameObject> windows = new();
    
    private void Start()
    {
        OpenWindow("Loading");
    }

    void Awake()
    {
        layout = this;
        foreach(GameObject window in windows)
        {

            window.SetActive(false);
        }
    }

    public void OpenWindow(string windowName)
    {
        foreach (GameObject window in windows)
        {
            if(window.name == windowName) window.SetActive(true);
            else window.SetActive(false);
        }

    }
    public void CreateRoom()
    {
        foreach (GameObject window in windows)
        {
            if(window.name == "Connect") window.SetActive(true);
            else window.SetActive(false);

        }

    }
}
