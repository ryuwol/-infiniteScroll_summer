using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inputtext : MonoBehaviour
{
    public Var var;
    public TMP_InputField inputField;
    public void endValueChange()
    {
        var.findname(inputField.text);
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
