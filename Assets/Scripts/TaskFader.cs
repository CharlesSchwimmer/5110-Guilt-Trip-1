using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;

public class TaskFader : MonoBehaviour
{
    public bool targetState = false;
    private float transitionRate = .3f;
    public Image screenFader;
    private float currentAlpha = 0f;
    public PlayerController playerController;
    public bool resetter = false;


    void Start()
    {
        currentAlpha = 0f;
        targetState = false;
        screenFader.color = new Color(screenFader.color.r, screenFader.color.g, screenFader.color.b, currentAlpha);
    }

void Update()
    {
        if (targetState == true)
        {
            taskComplete();
        }
    }
    public void SwitchBool(bool newState)
    {
        targetState = newState;
    }
    public void taskComplete()
    {
        playerController.canMove = false;
        float newAlpha;
        float originalAlpha;
        if (resetter == false)
        {
            FadeOut(out newAlpha, out originalAlpha);
            if (screenFader.color.a >= 1f)
            {
                resetter = true;
            }
        }
        if (resetter == true)
        {
            FadeIn(out newAlpha, out originalAlpha);
            if (screenFader.color.a == 0f)
            {
                playerController.canMove = true;
                targetState = false;
                resetter = false;
            }
        }
    }
 
    private void FadeIn(out float newAlpha, out float originalAlpha)
    {
        originalAlpha = screenFader.color.a;
        newAlpha = originalAlpha - (transitionRate * Time.deltaTime);
        newAlpha = Mathf.Min(1f, newAlpha);
        newAlpha = Mathf.Max(0f, newAlpha);
        screenFader.color = new Color(screenFader.color.r, screenFader.color.g, screenFader.color.b, newAlpha);
    }

    private void FadeOut(out float newAlpha, out float originalAlpha)
    {
        originalAlpha = screenFader.color.a;
        newAlpha = originalAlpha + (transitionRate * Time.deltaTime);
        newAlpha = Mathf.Min(1f, newAlpha);
        newAlpha = Mathf.Max(0f, newAlpha);
        screenFader.color = new Color(screenFader.color.r, screenFader.color.g, screenFader.color.b, newAlpha);
    }
}
