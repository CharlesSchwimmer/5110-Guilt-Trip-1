using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;
    public PlayerController pc;
    void Start()
    {
        footstep.GetComponent<AudioSource>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isMoving == true)
        {
            footstep.GetComponent<AudioSource>().enabled = true;
        }
        else
            footstep.GetComponent<AudioSource>().enabled = false;
    }
}
