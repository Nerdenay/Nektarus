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
                    convText.text = "O da ne ? Benim d���mda birimi ! Sen de kimsin ?";
                    a++;
                }
                else
                {
                    if(a == 1)
                    {
                        convText.text = "Gizemli Adam: A��k�as� bunu hi� ama hi� beklemiyordum madem burdas�n o zaman bana yard�m et?";
                        a++;
                    }
                    else if(a == 2)
                    {
                        convText.text = "Gizemli Adam: O kara g�nden beri burada tek ba��ma ya�amaya �al���yorum bir tek ben kald�m..";
                        a++;
                    }
                    else if(a == 3)
                    {
                        convText.text = "Yard�m m� ?";
                        a++;
                    }else if(a == 4)
                    {
                        convText.text = "Gizemli Adam: Evet benim i�in �ok ama �ok �nemli bir �ey bulmal�s�n.";
                        a++;
                    }else if(a == 5)
                    {
                        convText.text = "Neymi� O?";
                        a++;
                    }else if(a == 6)
                    {
                        convText.text = "Gizemli Adam: Buran�n do�usunda �al�lar�n ard�nda kaybettim. Bulunca anlars�n...";
                        a++;
                    }else if(a == 7)
                    {
                        convText.text = "Hmmm";
                        a++;
                    }else if(a == 8)
                    {
                        convText.text = "Gizemli Adam: Te�ekk�r ederim delikanl�.";
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
