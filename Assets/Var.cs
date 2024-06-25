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
    /*public string[] genders = { "여", "남", "선택안함" };
    public string[] firstnames = { "김", "이", "박", "최", "서", "황", "조", "정", "한", "남궁", "홍" };
    public string[] hobbies = { "독서", "여행", "요리", "그림 그리기", "사진 찍기", "음악 감상", "등산", "독서", "영화 감상", "게임" };
    public string[] femaleNames = { "이서", "지민", "수지", "예서", "지연", "미연", "지수", "미리", "미주", "규리", "하영", "이설", "설아" };
    public string[] maleNames = { "민준", "서준", "도윤", "하준", "주원", "지후", "현우", "준우", "건우", "도현", "예준", "시우" };
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
        if (gender == "여")
        {
            return first + femaleNames[Random.Range(0, femaleNames.Count)];
        }
        else if (gender == "남")
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
