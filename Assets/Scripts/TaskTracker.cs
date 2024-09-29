using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TaskTracker : MonoBehaviour
{
    public int maxTasks;
    public int currentTasks;
    public bool listening = false;
    public TaskFader taskFader;

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Tasks: " + currentTasks.ToString() + "/" + maxTasks.ToString();
    }


    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Tasks: " + currentTasks.ToString() + "/" + maxTasks.ToString();
    }
}
