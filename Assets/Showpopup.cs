using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Showpopup : MonoBehaviour
{
    public GameObject Popup;
    public GameObject PopupText;

    public void Click(Info info)
    {
        PopupText.GetComponent<TextMeshProUGUI>().text = "이름 : " + info.name + "\n" +  
                                                         "나이 : " + info.age + "\n" +
                                                         "성별 : " + info.gender + "\n" +
                                                         "취미 : " + info.hobby + "\n" + 
                                                         "직업 : " + info.job;
        Popup.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
