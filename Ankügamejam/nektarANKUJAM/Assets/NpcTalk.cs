using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcTalk : MonoBehaviour
{
    public Transform player;
    public GameObject textObj;
    public TextMeshProUGUI convText;
    private bool talked;
    private int a;
    public GameObject durum;

    private void Start()
    {
        a = 0;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position,player.position) < 3 && talked == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(textObj.activeSelf == false)
                {
                    textObj.SetActive(true);
                    convText.text = "O da ne ? Benim dýþýmda birimi ! Sen de kimsin ?";
                    a++;
                }
                else
                {
                    if(a == 1)
                    {
                        convText.text = "Gizemli Adam: Açýkçasý bunu hiç ama hiç beklemiyordum madem burdasýn o zaman bana yardým et?";
                        a++;
                    }
                    else if(a == 2)
                    {
                        convText.text = "Gizemli Adam: O kara günden beri burada tek baþýma yaþamaya çalýþýyorum bir tek ben kaldým..";
                        a++;
                    }
                    else if(a == 3)
                    {
                        convText.text = "Yardým mý ?";
                        a++;
                    }else if(a == 4)
                    {
                        convText.text = "Gizemli Adam: Evet benim için çok ama çok önemli bir þey bulmalýsýn.";
                        a++;
                    }else if(a == 5)
                    {
                        convText.text = "Neymiþ O?";
                        a++;
                    }else if(a == 6)
                    {
                        convText.text = "Gizemli Adam: Buranýn doðusunda çalýlarýn ardýnda kaybettim. Bulunca anlarsýn...";
                        a++;
                    }else if(a == 7)
                    {
                        convText.text = "Hmmm";
                        a++;
                    }else if(a == 8)
                    {
                        convText.text = "Gizemli Adam: Teþekkür ederim delikanlý.";
                        a++;
                        durum.SetActive(true);
                    }else if(a == 9)
                    {
                        talked = true;
                        textObj.SetActive(false);
                    }
                    
                }
            }
        }
    }
}
