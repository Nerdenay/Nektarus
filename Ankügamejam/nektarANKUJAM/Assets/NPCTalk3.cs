using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTalk3 : MonoBehaviour
{
    public Transform player;
    public GameObject textObj;
    public TextMeshProUGUI convText;
    private bool talked;
    private int a;

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
                    convText.text = "Noldu neden a�l�yosun ?";
                    a++;
                }
                else
                {
                    if (a == 1)
                    {
                        convText.text = "Gen� Kad�n: Annemden kalan �ok de�erli bir ta�� kaybettim ama o g�nden beri d��ar� ��kmaya korkuyorum.\r\n";
                        a++;
                    }
                    else if (a == 2)
                    {
                        convText.text = "�stersen onu senin i�in bulabilirim";
                        a++;
                    }
                    else if (a == 3)
                    {
                        convText.text = "Ne ger�ekten bunu yapar m�s�n ???";
                        a++;
                    }
                    else if (a == 4)
                    {
                        convText.text = "Elimden geleni yapar�m";
                        a++;
                    }
                    else if (a == 5)
                    {
                        convText.text = "(Kendi Kendine) Umar�m tahmin etti�im ta� de�ildir...";
                        a++;
                    }
                    else if (a == 6)
                    {
                        talked = true;
                        textObj.SetActive(false);
                    }
                }
            }
        }
        
    }
}
