using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{
    private string currentButtonName = "";

    private int RightAnswersPlayer;
    private int FalseAnswersPlayer;
    private bool Answercheck = false;

    //public int currentButtonClick = 0;

    public Transform dialogueBoxGUIQuestionButtons;


    private DialogueSystem dialogueSystem;
    ColorBlock cb2;
    Button ButtonA1;
    Text txt2;


    //public void SetText(string txt)
    //{
    //    Text txt2 = transform.Find("TextA").GetComponent<Text>();
    //    txt2.text = "hello";

    //}
    void Start()
    {
        
        dialogueSystem = DialogueSystem.FindObjectOfType<DialogueSystem>();
    }

    public bool Answercheck_()
    {
        return Answercheck;
    }

    public void setButtonName(string ButtonName)
    {
        Button Button1 = GameObject.Find(ButtonName).GetComponent<Button>();
        Text text1 = GameObject.Find("CheckAns").GetComponent<Text>();
        dialogueSystem.CheckAnswer(ButtonName,Button1,text1);
        //dialogueSystem.neutralizeButtonColor(Button1, text1);


        // dialogueSystem.DialogueBoxButtonToggle();
        //Answercheck = false;
        //currentButtonName = txt;
        //dialogueSystem.AnswersPlayer[dialogueSystem.currentButtonClick] = currentButtonName;

        //txt2 = GameObject.Find("CheckAns").GetComponent<Text>();
        //Answercheck = false;
        ////if (dialogueSystem.AnswersPlayer[dialogueSystem.currentQuestionIndex] == dialogueSystem.RightAnswers[dialogueSystem.currentQuestionIndex])
        //if (dialogueSystem.AnswersPlayer[dialogueSystem.currentButtonClick] == dialogueSystem.RightAnswers[dialogueSystem.currentButtonClick])
        //{
        //    ButtonA1 = GameObject.Find(currentButtonName).GetComponent<Button>();
        //    ColorBlock cb = ButtonA1.colors;
        //    cb.selectedColor = Color.green;
        //    ButtonA1.colors = cb;
        //    RightAnswersPlayer++;
        //    txt2.text = "Correct";
        //   // StartCoroutine(ExampleCoroutine());

        //    //dialogueSystem.DialogueBoxButtonSetActiveFalse();
        //    Answercheck = true;
        //    //dialogueSystem.CheckAnswerCheck(Answercheck);
        //}
        //else
        //{
        //    ButtonA1 = GameObject.Find(currentButtonName).GetComponent<Button>();
        //    cb2 = ButtonA1.colors;
        //    cb2.selectedColor = Color.red;
        //    ButtonA1.colors = cb2;
        //    FalseAnswersPlayer++;
        //    txt2.text = "False";

        //    StartCoroutine(ExampleCoroutine());

        //    //dialogueSystem.DialogueBoxButtonSetActiveFalse();
        //    Answercheck = true;
        //    //dialogueSystem.CheckAnswerCheck(Answercheck);
        //}
        //dialogueSystem.currentButtonClick++;

    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(5f);
    }



    //public string CurrentButtonName { get => currentButtonName; set => currentButtonName = value; }
    //public int CurrentButtonClick { get => currentButtonClick; set => currentButtonClick = value; }
    //public bool Answercheck1 { get => Answercheck; set => Answercheck = value; }

}
