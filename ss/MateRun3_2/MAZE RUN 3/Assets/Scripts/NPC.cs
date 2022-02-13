using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform ChatBackGroundQuestion;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;
    private StarterAssets.ThirdPersonController thirdPersonController;
    private int currentQuestionIndex;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;
    public bool[] IfQuestions;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); //finds Dialogue System 
        thirdPersonController = FindObjectOfType<StarterAssets.ThirdPersonController>();
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
          Pos.y += 175;
          ChatBackGround.position = Pos;
        Vector3 PosQ = Pos;         //Position of the Qestion Buttons
        PosQ.y -= 80;
        PosQ.x += 90;
        ChatBackGroundQuestion.position = PosQ;
    }

    public void OnTriggerStay(Collider other)
    {
        if (!(other.gameObject.tag == "Ball"))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            //dialogueSystem.currentDialogueIndex = dialogueindex;
            if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                dialogueSystem.dialogueIsQuestion = IfQuestions;
                //dialogueSystem.currentQuestionIndex = currentQuestionIndex;
                FindObjectOfType<DialogueSystem>().NPCName();
                thirdPersonController.LockCamera();
            }
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
        thirdPersonController.UnlockCamera();
    }
}

