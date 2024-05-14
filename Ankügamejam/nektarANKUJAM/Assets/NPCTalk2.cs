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
                    convText.text = "Hey, buralarda bazý taþlar arýyorum nerde olduklarýný biliyormusun?";
                    a++;
                }
                else
                {
                    if (a == 1)
                    {
                        convText.text = "Robot: Aradýðýn o taþlardan biri bende.";
                        a++;
                    }
                    else if (a == 2)
                    {
                        convText.text = "Robot: Eðer bilmecelerimi bilirsen sana bu taþý veririm";
                        a++;
                    }
                    else if (a == 3)
                    {
                        convText.text = "Peki neymiþ bu bilmeceler";
                        a++;
                    }
                    else if (a == 4)
                    {
                        convText.text = "Robot: Kuyruðu var, at deðil. Kanadý var, kuþ deðil.";
                        a++;
                    }
                    else if (a == 5)
                    {
                        convText.text = "Balýk";
                        a++;
                    }
                    else if (a == 6)
                    {
                        convText.text = "Robo: Gökte durur paslanmaz, suya düþer ýslanmaz.";
                        a++;
                    }
                    else if (a == 7)
                    {
                        convText.text = "Hmmm";
                        a++;
                    }
                    else if (a == 8)
                    {
                        convText.text = "Güneþ";
                        a++;
                    }
                    else if(a == 9)
                    {
                        convText.text = "Robot: Beni yendin iþte, al taþýný ve git burdan.";
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
