using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonInfo : MonoBehaviour
{
    public GameObject Text;
    public GameObject Text_detail;
    public Info Info;
    private void Start()
    {
        this.gameObject.name = Info.name;
        Text.GetComponent<TextMeshProUGUI>().text = Info.name;
        Text_detail.GetComponent<TextMeshProUGUI>().text= "나이 : "+ Info.age +"\n"+
                                                          "직업 : " + Info.job;
    }
    public void Click()
    {
        var manager = GameObject.Find("Manager");
        manager.GetComponent<Showpopup>().Click(Info);
    }
}
