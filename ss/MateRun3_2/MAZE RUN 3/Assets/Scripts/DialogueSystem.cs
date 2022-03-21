using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem: MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;
    public Transform dialogueBoxGUIQuestion;
    public Transform dialogueBoxGUIQuestionButtons;

    private StarterAssets.ThirdPersonController thirdPersonController;

    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.F;

    public string Names;

    public string[] dialogueLines;
    public bool[] dialogueIsQuestion;
    public int currentDialogueIndex;
    public int currentQuestionIndex;
    public int currentButtonClick;


    public bool letterIsMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;
    public bool QuestionAnswered = true;

    public bool IsQuestin = false;
    private bool test = false;
    private bool answerCheck = false;

    public AudioClip audioClip;
    AudioSource audioSource;

    public string[] AnswersPlayer;
    public string[] RightAnswers = new string[] { "ButtonA", "ButtonB", "ButtonC", "ButtonD", "ButtonA", "ButtonB", "ButtonC", "ButtonD" };
    private int falseAnswers = 0;


    public bool answered = false;
    private bool ButtonReset = false;
    private Button Button1;
    private Text text1;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        thirdPersonController = FindObjectOfType<StarterAssets.ThirdPersonController>();
        dialogueText.text = "";
        Cursor.visible = true;
        currentButtonClick = 0;
    }


    public void EnterRangeOfNPC()
    {
        //currentButtonClick = 0;       Wenn noch mehrere Charakter kommen dann muss 
        outOfRange = false;
        dialogueGUI.SetActive(true);    //F to chat
        if (dialogueActive == true)
        {
            dialogueGUI.SetActive(false);  //wenn andere Dialog geöffnet ist, dann schließen
        }
    }

    public void NPCName()
    {
        //if (QuestionAnswered)
        //{
        //    QuestionAnswered = false;
            outOfRange = false;
            Cursor.lockState = CursorLockMode.None;

            dialogueGUI.SetActive(false);           //F to chat
            dialogueBoxGUI.gameObject.SetActive(true);      //GUI Dialogue
            dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);      //GUI Dialogue Button

            nameText.text = Names;
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!dialogueActive)
                {
                    dialogueActive = true;
                   
                    StartCoroutine(StartDialogue());    //start it
                }
            }
            StartDialogue();    //get it
        
    }



    private IEnumerator StartDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;

            
            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                   // QuestionAnswered = true;
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));
                    if (ButtonReset)
                    {
                        neutralizeButtonColor(Button1, text1);
                        ButtonReset = false;
                    }
                    if (dialogueIsQuestion[currentDialogueIndex-1])
                    {
                        dialogueBoxGUIQuestionButtons.gameObject.SetActive(true);
                        ButtonReset = true;
                    }
                    else
                    {
                        dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
                    }
                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }

            while (true)
            {
                if (Input.GetKeyDown(DialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
            //currentQuestionIndex = 0;
        }
    }





    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";
            IsQuestin = false;

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;



                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(DialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);
                        
                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);

                    }
                    else
                    { 
                    
                        yield return new WaitForSeconds(letterDelay);

                        if (audioClip) audioSource.PlayOneShot(audioClip, 0.5F);
                    }
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {       
        dialogueGUI.SetActive(false);
        dialogueBoxGUI.gameObject.SetActive(false);
        dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            dialogueGUI.SetActive(false);
            dialogueBoxGUI.gameObject.SetActive(false);
            dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
        }
    }

    //public void DialogueBoxButtonSetActiveFalse()
    //{
    //    StartCoroutine(ExampleCoroutine());
    //    dialogueBoxGUIQuestionButtons.gameObject.SetActive(false);
    //}
    //public void CheckAnswerCheck(bool answercheck1)
    //{
    //    answerCheck = answercheck1;
    //}

    //IEnumerator ExampleCoroutine()
    //{
    //    yield return new WaitForSeconds(100f);
    //    yield return new WaitForSeconds(500f);
    //}

    public void CheckAnswer(string ButtonName, Button Button2, Text text2)
    {

        Button1 = Button2;
        text1 = text2;
        AnswersPlayer[currentButtonClick] = ButtonName;
        if (AnswersPlayer[currentButtonClick] == RightAnswers[currentButtonClick])
        {
            ColorBlock cb = Button1.colors;
            cb.selectedColor = Color.green;
            Button1.colors = cb;
            text1.text = "Correct";
        }
        else
        {
            falseAnswers++;
            thirdPersonController.TakeDamage(10000);
            ColorBlock cb = Button1.colors;
            cb.selectedColor = Color.red;
            Button1.colors = cb;
            text1.text = "False";
        }
        currentButtonClick++;
    }

    public void neutralizeButtonColor(Button Button1, Text text1)
    {
        ColorBlock cb = Button1.colors;
        cb.selectedColor = Color.white;
        Button1.colors = cb;
        text1.text = "Checking Answer...";
    }
}
