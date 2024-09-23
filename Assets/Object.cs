using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject Activatable;
    [SerializeField] public bool interactible;
    public int myRoom;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactible)
        {
            ShowFloatingText();
        }
    }

    public void ShowFloatingText()
    {
        /*private void OnNetworkInstantiate(UnityEngine.NetworkMessageInfo info)
        {
            FloatingTextPrefab, transform.position, 
        }*/
        Debug.Log("Interactible!");
        return;
    }
}
