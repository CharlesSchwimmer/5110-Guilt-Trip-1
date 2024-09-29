using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TimeRemaining : MonoBehaviour
{
    public PlayerController controller;
    public float timeLeft;
    public float xScale;
    public float yScale;
    private void Start()
    {
        xScale = GetComponent<RectTransform>().sizeDelta.x;
        yScale = GetComponent<RectTransform>().sizeDelta.y;
    }
    private void Update()
    {
        timeLeft = 1;
        GetComponent<RectTransform>().sizeDelta = new Vector2(xScale * (controller.timeTracker / controller.dayTimer), yScale);
    }

}
