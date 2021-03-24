using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialogueParser : MonoBehaviour
{
    public TextAsset txtFile;
    private string[] lines;
    private int currentLine  = 0;
    private bool isFinished = false;
    private string charName = "";
    private string dialogue = "";

    public Text name;
    public Text dialogueTxt;
    // Start is called before the first frame update
    void Start()
    {
        string text = txtFile.text;
        lines = text.Split('\n');

    }

    // Update is called once per frame
    void Update()
    {
        parse();
    }

    public void parse()
    {
        if(!isFinished)
        {
            string lineStr = lines[currentLine];
            string[] tokens = lineStr.Split(' ');
            charName = getCharacterName(tokens);
            

            print(charName);
            print(dialogue);
            name.text = charName;
            dialogueTxt.text = dialogue;
            isFinished = !isFinished;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentLine++;
            isFinished = !isFinished;
        }
    }

    string getCharacterName(string[] tokens)
    {
        bool isNameFound = false;
        string charName = "";
        int dialogueStart = 0;
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
            dialogueStart++;
            if(isNameFound)
            {
                break;
            }
            charName += ' ';
        }
        getDialogue(tokens, dialogueStart);
        return charName;
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
}
