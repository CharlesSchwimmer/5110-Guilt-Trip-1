using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int myRoom;
    public float resetTime;
    public float resetCountdown;
    public TaskFader taskFader;

    [Header("Sprites")]
    public bool needsStages;
    public Sprite startStage;
    public Sprite midStage;
    public Sprite endStage;

    [Header("Text Prompts")]
    public int stage;
    public string prompt;
    public string text1;
    public string text2;
    public string text3;
    public string failText;
    public string successText;

    void Start()
    {
        if (needsStages)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = startStage;
        }
    }

void Update()
    {
        
    }
    public string ReadText()
    {
        if (stage ==1)
        {
            return text2 + "                                         " + prompt;
        }
        if (stage == 2)
        {
            return text2 + "                                         " + prompt;
        }
        if (stage ==3)
        {
            return text3 + "                                         " + prompt;
        }
        if(stage ==0)
        {
            return successText;
        }
        else 
            return successText;
    }
    public void ProgressStage(Sprite midStage, Sprite endStage)
    {
        if (stage > 0 && stage < 4)
        {
            stage++;
        }
        if(stage == 2 && needsStages)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = midStage;
        }
        if(stage ==3 && needsStages)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = endStage;
        }
        if (stage == 0 && needsStages)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = startStage;
        }
    }
    
    public void TaskComplete(){
        if (stage > 0)
        {
            taskFader.SwitchBool(true);
        }
        stage = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = startStage;
    }
}
