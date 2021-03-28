using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialogueParser : MonoBehaviour
{
    public TextAsset txtFile;
    public player_control player;
    private string[] lines;
    private int currentLine = 0;
    private bool isFinished = false;
    private string charName = "";
    private string dialogue = "";
    private GameObject dialogueBox;
    private bool isInteracted = false;
    private string[] emoticons = { ":|", ":)", ">:(", ":O" };
    private int[] who = {1, 2};
    public Image emote;
    public Sprite[] emoteSprites1;
    public Sprite[] emoteSprites2;

    public Text name;
    public Text dialogueTxt;
    // Start is called before the first frame update
    void Start()
    {
        string text = txtFile.text;
        lines = text.Split('\n');
        dialogueBox = GameObject.FindGameObjectWithTag("DBox");
        dialogueBox.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(isInteracted)
        {

            parse();
        }
    }

    public void parse()
    {
        if(!isFinished)
        {
            string lineStr = lines[currentLine];
            string[] tokens = lineStr.Split(' ');

            if (tokens[0] == "END")
            {
                isFinished = true;
                dialogueBox.SetActive(false);
                player.setCanMove(true);
                isInteracted = false;
            }
           
            

            if(!isFinished)
            {
                charName = getCharacterName(tokens);
                name.text = charName;
                dialogueTxt.text = dialogue;
                isFinished = !isFinished;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
            isFinished = !isFinished;
        }
    }

    string getCharacterName(string[] tokens)
    {
        bool isNameFound = false;
        string charName = "";
        int emoticonStart = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            string curToken = tokens[i];

            for(int j = 0; j < curToken.Length; j++)
            {
                if(!isNameFound)
                {
                    if (curToken[j] != ':')
                    {
                        charName += curToken[j];
                    }
                    else
                    {
                        isNameFound = true;
                        break;
                    }
                }
            }
            emoticonStart++;
            if(isNameFound)
            {
                break;
            }
            charName += ' ';
        }

        int dialogueStart = getCharEmotion(tokens, emoticonStart);
        getDialogue(tokens, dialogueStart);
        return charName;
    }

    int getCharEmotion(string[] tokens, int emoticonStart)
    {
        int dialogueStart = emoticonStart + 1;
        bool isEmoteFound = false;
        int currChar = 0;

        if((tokens[emoticonStart]) == "1")
        {
            currChar = 0;
            for (int i = emoticonStart; i < tokens.Length; i++)
            {
                if (isEmoteFound)
                {
                    break;
                }

                for (int j = 0; j < emoticons.Length; j++)
                {
                    if (tokens[i] == emoticons[j])
                    {
                        emote.sprite = emoteSprites1[j];
                        dialogueStart++;
                        isEmoteFound = true;

                    }
                }
            }
        }
        else
        {
            currChar = 1;
            for (int i = emoticonStart; i < tokens.Length; i++)
            {
                if (isEmoteFound)
                {
                    break;
                }

                for (int j = 0; j < emoticons.Length; j++)
                {
                    if (tokens[i] == emoticons[j])
                    {
                        emote.sprite = emoteSprites2[j];
                        dialogueStart++;
                        isEmoteFound = true;

                    }
                }
            }
        }

        
        return dialogueStart;
    }
    string getDialogue(string[] tokens, int startPos)
    {
        string curDialogue = "";


        for(int i = startPos; i < tokens.Length; i++)
        {
            string token = tokens[i];
            if(i==startPos)
            {
                token = token.Substring(1);
            }
            
            for(int j = 0; j < token.Length; j++)
            {
                if(token[j]!='\"')
                {
                    curDialogue += token[j];
                }

                else
                {
                    break;
                }
            }

            curDialogue += ' ';

        }


         dialogue = curDialogue;
        return dialogue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.tag=="Interact")
        {
            isInteracted = true;
            player.setCanMove(false);
            dialogueBox.SetActive(true);
        }
    }

    public void setIsInteracted(bool newState)
    {
        this.isInteracted = newState;
        player.setCanMove(!newState);
        dialogueBox.SetActive(newState);
    }
}
