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
    public string CharacterName;
    int tableSize;

    public TextAsset textAssetData;
    string[] data;

    [TextArea(5, 10)]
    public string[] sentences;
    public bool[] IfQuestions;

    public class PlayerL
    {
        public string name;
        public string[] dialogueL = new string[5];
        public bool[] ifQuesL = new bool[5];
        public string[] AnswersL = new string[5];
    }


    public class PlayerList
    {
        public PlayerL[] playerL;
    }
    public PlayerList myPlayerList = new PlayerList();


    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); //finds Dialogue System 
        thirdPersonController = FindObjectOfType<StarterAssets.ThirdPersonController>();
        ReadCSV();
    }
	
	void Update () {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y += 175;
        ChatBackGround.position = Pos;          //sets the position of the Dialog text
        Vector3 PosQ = Pos;         
        PosQ.y -= 80;
        PosQ.x += 90;
        ChatBackGroundQuestion.position = PosQ; //sets the position of the Qestion Buttons
    }

    public void OnTriggerStay(Collider other)
    {
        if (!(other.gameObject.tag == "Ball"))  //ignore the Ball object as a trigger
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;

                for (int i = 0; i < tableSize; i++)
                {
                    if (CharacterName == myPlayerList.playerL[i].name)
                    {
                        dialogueSystem.dialogueLines = myPlayerList.playerL[i].dialogueL;
                        dialogueSystem.dialogueIsQuestion = myPlayerList.playerL[i].ifQuesL;
                        dialogueSystem.AnswersPlayer = myPlayerList.playerL[i].AnswersL;
                    }
                }
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

    void ReadCSV()
    {
        data = textAssetData.text.Split(new string[] { ";", "\n" }, System.StringSplitOptions.None);
        tableSize = data.Length / 16 - 1;
        myPlayerList.playerL = new PlayerL[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myPlayerList.playerL[i] = new PlayerL();
            myPlayerList.playerL[i].name = data[16 * (i + 1)];

            for (int j = 0; j < 5; j++)
            {
                myPlayerList.playerL[i].dialogueL[j] = data[16 * (i + 1) + 1 + j];
                myPlayerList.playerL[i].ifQuesL[j] = System.Convert.ToBoolean(data[16 * (i + 1) + 2 + j + 4]);
                myPlayerList.playerL[i].AnswersL[j] =data[16 * (i + 1) + 3 + j + 8];
            }
        }
    }
}

