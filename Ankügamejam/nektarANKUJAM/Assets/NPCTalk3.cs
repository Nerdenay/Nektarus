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
                    convText.text = "Noldu neden aðlýyosun ?";
                    a++;
                }
                else
                {
                    if (a == 1)
                    {
                        convText.text = "Genç Kadýn: Annemden kalan çok deðerli bir taþý kaybettim ama o günden beri dýþarý çýkmaya korkuyorum.\r\n";
                        a++;
                    }
                    else if (a == 2)
                    {
                        convText.text = "Ýstersen onu senin için bulabilirim";
                        a++;
                    }
                    else if (a == 3)
                    {
                        convText.text = "Ne gerçekten bunu yapar mýsýn ???";
                        a++;
                    }
                    else if (a == 4)
                    {
                        convText.text = "Elimden geleni yaparým";
                        a++;
                    }
                    else if (a == 5)
                    {
                        convText.text = "(Kendi Kendine) Umarým tahmin ettiðim taþ deðildir...";
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
