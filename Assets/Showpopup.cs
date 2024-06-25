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
        PopupText.GetComponent<TextMeshProUGUI>().text = info.name;
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
