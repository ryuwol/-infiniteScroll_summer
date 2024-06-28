using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public GameObject detail;
    [SerializeField] TMP_Text text;
    public void OnDropDownEvent(TMP_Dropdown index)
    {
        detail.GetComponent<SelectDetail>().inputvalue(index.value);
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
