using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTalk2 : MonoBehaviour
{
    public Transform player;
    public GameObject textObj;
    public TextMeshProUGUI convText;
    private bool talked;
    private int a;
    public GameObject stone;

    private void Start()
    {
        a = 0;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 3 && talked == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textObj.activeSelf == false)
                {
                    textObj.SetActive(true);
                    convText.text = "Hey, buralarda baz� ta�lar ar�yorum nerde olduklar�n� biliyormusun?";
                    a++;
                }
                else
                {
                    if (a == 1)
                    {
                        convText.text = "Robot: Arad���n o ta�lardan biri bende.";
                        a++;
                    }
                    else if (a == 2)
                    {
                        convText.text = "Robot: E�er bilmecelerimi bilirsen sana bu ta�� veririm";
                        a++;
                    }
                    else if (a == 3)
                    {
                        convText.text = "Peki neymi� bu bilmeceler";
                        a++;
                    }
                    else if (a == 4)
                    {
                        convText.text = "Robot: Kuyru�u var, at de�il. Kanad� var, ku� de�il.";
                        a++;
                    }
                    else if (a == 5)
                    {
                        convText.text = "Bal�k";
                        a++;
                    }
                    else if (a == 6)
                    {
                        convText.text = "Robo: G�kte durur paslanmaz, suya d��er �slanmaz.";
                        a++;
                    }
                    else if (a == 7)
                    {
                        convText.text = "Hmmm";
                        a++;
                    }
                    else if (a == 8)
                    {
                        convText.text = "G�ne�";
                        a++;
                    }
                    else if(a == 9)
                    {
                        convText.text = "Robot: Beni yendin i�te, al ta��n� ve git burdan.";
                        a++;
                        stone.SetActive(true);
                    }else if(a == 10)
                    {
                        talked = true;
                        textObj.SetActive(false);
                    }
                }
            }
        }
    }
}
