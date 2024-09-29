using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;

public class ResetFader : MonoBehaviour
{
    [Header("Connectors")]
    public Image screenFader;          
    public PlayerController playerController;
    public DayTracker dayTracker;

    [Header("Trackers")]
    public bool targetState = false;
    private float transitionRate = .5f;
    private float currentAlpha = 0f;
    private bool fadeInBool = false;
    public bool isResetting = false;

    void Start()
    {
        currentAlpha = 0f;
        targetState = false;
        screenFader.color = new Color(screenFader.color.r, screenFader.color.g, screenFader.color.b, currentAlpha);
    }

void Update()
    {
        if (targetState == true) 
            WorldReset();
        if (targetState == false)
        {
            isResetting = false;
        }
    }
    public void SwitchBool(bool newState)
    {
        targetState = newState;
    }

    public void WorldReset()
    {
        isResetting = true;
        float newAlpha;
        float originalAlpha;
        if (fadeInBool == true)
        {
            FadeIn(out newAlpha, out originalAlpha);
            if (screenFader.color.a <= 0f)
            {
                playerController.canMove = true;
                SwitchBool(false);
                fadeInBool = false;
            }
        }
        if (targetState == true && fadeInBool ==false)
        {
            playerController.canMove = false;
            FadeOut(out newAlpha, out originalAlpha);
            if (screenFader.color.a >= 1f)
            {
                playerController.transform.position = playerController.originPosition;
                foreach (var Entity in playerController.interactibles)
                {
                    if (Entity.stage == 1 || Entity.stage == 2)
                        Entity.ProgressStage(Entity.midStage, Entity.endStage);
                   
                }
                fadeInBool = true;
                dayTracker.dayTracker++;
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
