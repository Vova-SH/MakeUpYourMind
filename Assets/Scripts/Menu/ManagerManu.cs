using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerManu : MonoBehaviour
{
    public Color active = new Color(0f, 0f, 0f, 0f);
    public Color noActive = new Color(1f, 0f, 1f, 0.1f);

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "Play")
        {
            print("играть");
        }
        if (gameObject.name == "Exit")
        {
            print("выход");
            Application.Quit();
        }
    }

    private void OnMouseOver()
    {
        this.gameObject.transform.localScale = new Vector3(30, 10, 10);
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = active;
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.localScale = new Vector3(25, 9, 9);
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = noActive;
    }
}
