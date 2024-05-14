using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textspeed;

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

    }
    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    void NextLine()
    {
        if (index < lines.Length)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (typeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator typeLine()
    {
        foreach (var cha in lines[index].ToCharArray())
        {
            textComponent.text += cha;

            yield return new WaitForSeconds(textspeed);


        }
    }
}
