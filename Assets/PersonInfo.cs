using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonInfo : MonoBehaviour
{
    public GameObject Text;
    public Info Info;
    private void Start()
    {
        Text.GetComponent<TextMeshProUGUI>().text = Info.name;
    }
    public void Click()
    {
        var manager = GameObject.Find("Manager");
        manager.GetComponent<Showpopup>().Click(Info);
    }
}
