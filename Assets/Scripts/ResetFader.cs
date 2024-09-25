using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;

public class ResetFader : MonoBehaviour
{
    public bool targetState = false;
    private float transitionRate = 2f;
    public Image screenFader;
    private float currentAlpha = 0f;
    public PlayerController playerController;


    void Start()
    {
        currentAlpha = 1f;
        targetState = false;
        screenFader.color = new Color(screenFader.color.r, screenFader.color.g, screenFader.color.b, currentAlpha);
    }

void Update()
    {
        WorldReset();
    }
    public void SwitchBool(bool newState)
    {
        targetState = newState;
    }
    public void taskComplete()
    {
        float newAlpha;
        float originalAlpha;
        if (targetState == true)
        {
            FadeOut(out newAlpha, out originalAlpha);
            if (screenFader.color.a >= 1f)
            {
                SwitchBool(false);
            }
        }
        else
        {
            FadeIn(out newAlpha, out originalAlpha);
        }
    }
        public void WorldReset()
    {
        float newAlpha;
        float originalAlpha;
        if (targetState == true)
        {
            FadeOut(out newAlpha, out originalAlpha);
            if (screenFader.color.a >= 1f)
            {
                playerController.transform.position = playerController.originPosition;
                SwitchBool(false);
            }
        }
        else
        {
            FadeIn(out newAlpha, out originalAlpha);
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
