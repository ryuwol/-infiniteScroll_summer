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
    public string[] genders = { "��", "��", "���þ���" };
    public string[] firstnames = { "��", "��", "��", "��", "��", "Ȳ", "��", "��", "��", "����", "ȫ" };
    public string[] hobbies = { "����", "����", "�丮", "�׸� �׸���", "���� ���", "���� ����", "���", "����", "��ȭ ����", "����" };
    public string[] femaleNames = { "�̼�", "����", "����", "����", "����", "�̿�", "����", "�̸�", "����", "�Ը�", "�Ͽ�", "�̼�", "����" };
    public string[] maleNames = { "����", "����", "����", "����", "�ֿ�", "����", "����", "�ؿ�", "�ǿ�", "����", "����", "�ÿ�" };

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

            var newButton = Instantiate(Button);
            newButton.transform.SetParent(Content.transform);
            newButton.GetComponent<PersonInfo>().Info = newInfo;
        }
        Debug.Log(info[3].hobby);
    }

    string RandomGender()
    {
        return genders[Random.Range(0, genders.Length)];
    }
    string RandomName(string gender)
    {
        string first = firstnames[Random.Range(0, firstnames.Length)];
        if (gender == "��")
        {
            return first + femaleNames[Random.Range(0, femaleNames.Length)];
        }
        else if (gender == "��")
        {
            return first + maleNames[Random.Range(0, maleNames.Length)];
        }
        else
        {
            return first + femaleNames.Concat(maleNames).ToArray()[Random.Range(0, femaleNames.Length + maleNames.Length)];
        }
    }

    string RandomHobby()
    {
        return hobbies[Random.Range(0, hobbies.Length)];
    }

    public void Start()
    {
        
    }
}
