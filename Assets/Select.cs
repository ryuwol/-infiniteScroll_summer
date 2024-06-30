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
    public void OnDropDownEvent(int num)
    {
        detail.GetComponent<SelectDetail>().inputvalue(num);
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
