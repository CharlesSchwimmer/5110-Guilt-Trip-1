using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TMP_Text[] Tasks;

    public void ShowCredit(){
        SceneManager.LoadScene("Credit");
    }


    //GetComponent<TextMeshProUGUI>().text = "Day: " + dayTracker.ToString() + " / 3";
    private void Start()
    {
        //"fuck u".ToString();
    }

    private void Update()
    {
        
    }




}
