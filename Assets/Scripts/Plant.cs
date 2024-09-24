using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Entity
{
    void Start()
    {
        
    }
    void Update()
    {
        if (stage == 2)
            GetComponentInChildren<SpriteRenderer>().color = new Color(155,155,0);
        else if (stage == 3)
            GetComponentInChildren<SpriteRenderer>().color = new Color(50, 0, 0);
    }

    public void ShowFloatingText()
    {

    }
}
