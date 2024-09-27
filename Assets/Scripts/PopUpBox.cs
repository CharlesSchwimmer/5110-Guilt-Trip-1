using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using TMPro;

public class PopUpBox : MonoBehaviour
{
   public GameObject popUpBox;
   public Animator animator;
   public TMP_Text popUpText;
   public Entity entity;

   public void popUp(Entity interactible){
        entity = interactible;
        popUpBox.SetActive(true);
        popUpText.text = interactible.ReadText();
        animator.SetTrigger("pop");
   }

   public void respond(){
        entity.taskComplete();
   }
}
