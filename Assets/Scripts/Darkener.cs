using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Darkener : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public PlayerController playerController;
    [SerializeField] private int myRoom = 1;
    private int playerRoom;

    void Update()
    {
        playerRoom = playerController.myRoom;
        if (playerController && myRoom == playerRoom)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
