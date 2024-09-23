using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int myRoom;
    public int stage;
    public string prompt;
    public string text1;
    public string text2;
    public string text3;
    public string failText;
    public string successText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string ReadText()
    {
        if (stage ==1)
        {
            return text1;
        }
        if (stage == 2)
        {
            return text2;
        }
        else
        {
            return text3;
        }
    }
    public void ProgressStage()
    {
        stage++;
    }
}
