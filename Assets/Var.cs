using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Info
{
    public string name;
    public string gender;
    public string hobby;
    public int age;
}

public class Var : MonoBehaviour
{
    public List<Info> info = new List<Info>();
    public bool ran;
    /*public string[] genders = { "��", "��", "���þ���" };
    public string[] firstnames = { "��", "��", "��", "��", "��", "Ȳ", "��", "��", "��", "����", "ȫ" };
    public string[] hobbies = { "����", "����", "�丮", "�׸� �׸���", "���� ���", "���� ����", "���", "����", "��ȭ ����", "����" };
    public string[] femaleNames = { "�̼�", "����", "����", "����", "����", "�̿�", "����", "�̸�", "����", "�Ը�", "�Ͽ�", "�̼�", "����" };
    public string[] maleNames = { "����", "����", "����", "����", "�ֿ�", "����", "����", "�ؿ�", "�ǿ�", "����", "����", "�ÿ�" };
    */
    public List<string> genders = new List<string>();
    public List<string> firstnames = new List<string>();
    public List<string> hobbies = new List<string>();
    public List<string> femaleNames = new List<string>();
    public List<string> maleNames = new List<string>();
    public GameObject Button;
    public GameObject Content;
    public void Awake()
    {
        if (ran)
        {
            Randominfo(500);
        }
    }

    void Randominfo(int num)
    {
        info.Clear();
        for (int i = 0; i < num; i++)
        {
            Info newInfo = new Info();
            newInfo.gender = RandomGender();
            newInfo.name = RandomName(newInfo.gender);
            newInfo.hobby = RandomHobby();
            newInfo.age = Random.Range(20, 61);

            info.Add(newInfo);
            GameObject newButton = Instantiate(Button);
            newButton.transform.SetParent(Content.transform);
            newButton.GetComponent<PersonInfo>().Info = newInfo;
        }
        Debug.Log(info[3].hobby);
    }

    string RandomGender()
    {
        return genders[Random.Range(0, genders.Count)];
    }
    string RandomName(string gender)
    {
        string first = firstnames[Random.Range(0, firstnames.Count)];
        if (gender == "��")
        {
            return first + femaleNames[Random.Range(0, femaleNames.Count)];
        }
        else if (gender == "��")
        {
            return first + maleNames[Random.Range(0, maleNames.Count)];
        }
        else
        {
            return first + femaleNames.Concat(maleNames).ToArray()[Random.Range(0, femaleNames.Count + maleNames.Count)];
        }
    }

    string RandomHobby()
    {
        return hobbies[Random.Range(0, hobbies.Count)];
    }

    public void Start()
    {
        
    }
}
