using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] SentencesDialog;
    private int Index = 0;
    public float DialogSpeed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //OnClick();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextSentenseDialog();
        }
    }

    //public void OnClick()
    //{
        //NextSentenseDialog();
    //}

    void NextSentenseDialog()
    {
        if(Index <= SentencesDialog.Length -1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentenceText());
        }
    }

    IEnumerator WriteSentenceText()
    {
        foreach (char Character in SentencesDialog[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogSpeed);
        }
        Index++;
    }
}
