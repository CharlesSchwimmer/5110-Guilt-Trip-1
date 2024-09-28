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
   public Button buttonYes;
   public Button buttonNo;
   public Entity entity;
   public AnimationEvent anim;
    public ResetFader ResetFader;
   void Start(){
        buttonYes.onClick.AddListener(Respond);
   }

   public void PopUp(Entity interactible){
        entity = interactible;
        popUpBox.SetActive(true);
        popUpText.text = interactible.ReadText();
        animator.SetTrigger("pop");
   }

    public void DoneTask(Entity interactible)
    {
        entity = interactible;
        popUpBox.SetActive(true);
        popUpText.text = interactible.ReadText();
        animator.SetTrigger("pop");
    }

    public void Respond(){
        entity.TaskComplete();
   }
}
