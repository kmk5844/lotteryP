using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{
    public GameObject Button;
    bool ButtonFlag = false;
    public GameObject Card;
    public Transform gridParent;

    public TMP_Text text_count;
    public TMP_Text text_1;
    public TMP_Text text_2;
    public TMP_Text text_3;
    public TMP_Text text_4;
    public TMP_Text text_S;
    public TMP_Text text_gift;

    public List<int> list = new List<int>();
    public List<int> first_list = new List<int>();
    public List<int> second_list = new List<int>();
    public List<int> thrid_list = new List<int>();
    public List<int> fourth_list = new List<int>();
    public List<int> special_list = new List<int>();

    public TMP_InputField First_inputField;
    public TMP_InputField Second_inputField;
    public TMP_InputField Thrid_inputField;
    public TMP_InputField Fourth_inputField;
    public TMP_InputField Special_inputField;

    int inputNum1 = -1;
    int inputNum2 = -1;
    int inputNum3 = -1;
    int inputNum4 = -1;
    int inputNum5 = -1;

    int count;
    int first = 0;
    int second = 0;
    int thrid = 0;
    int fourth = 0;
    int special = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        count = PlayerPrefs.GetInt("Count");
        for(int i = 1; i <= count; i++)
        {
            list.Add(i);
        }
        Time.timeScale = 0f;
    }

    void Start()
    {
        string countString = "추첨 인원 : " + count + "명";
        text_count.text = countString;
        First_inputField.onValueChanged.AddListener(OnInputField1ValueChanged);
        Second_inputField.onValueChanged.AddListener(OnInputField2ValueChanged);
        Thrid_inputField.onValueChanged.AddListener(OnInputField3ValueChanged);
        Fourth_inputField.onValueChanged.AddListener(OnInputField4ValueChanged);
        Special_inputField.onValueChanged.AddListener(OnInputField5ValueChanged);
    }

    
    private void OnInputField1ValueChanged(string Num)
    {
        inputNum1 = int.Parse(Num);
    }
    private void OnInputField2ValueChanged(string Num)
    {
        inputNum2 = int.Parse(Num);
    }
    private void OnInputField3ValueChanged(string Num)
    {
        inputNum3 = int.Parse(Num);
    }
    private void OnInputField4ValueChanged(string Num)
    {
        inputNum4 = int.Parse(Num);
    }
    private void OnInputField5ValueChanged(string Num)
    {
        inputNum5 = int.Parse(Num);
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonFlag == false)
        {
            if (inputNum1 + inputNum2 + inputNum3 + inputNum4 + inputNum5 <= count && inputNum1 != -1 && inputNum2 != -1 && inputNum3 != -1 && inputNum4 != -1 && inputNum5 != -1)
            {
                Button.SetActive(true);
            }
            else
            {
                Button.SetActive (false);
            }
        }
        
    }

    void RandomNumber()
    {
        bool Flag1 = true;
        bool Flag2 = false;
        bool Flag3 = false;
        bool Flag4 = false;
        bool FlagS = false;
        first = PlayerPrefs.GetInt("First");
        second = PlayerPrefs.GetInt("Second");
        thrid = PlayerPrefs.GetInt("Thrid");
        fourth = PlayerPrefs.GetInt("Fourth");
        special = PlayerPrefs.GetInt("Special");
 
        int num = 0;
        while(true)
        {   
            int rand = UnityEngine.Random.Range(1, count + 1);
            
            if (Flag1 && !Flag2 && !Flag3 && !Flag4 && !FlagS)
            {
                if (first == num)
                {
                    Flag1 = false;
                    Flag2 = true;
                    num = 0;
                    continue;
                }

                if (list.Contains(rand))
                {
                    first_list.Add(rand);
                    list.Remove(rand);
                    num++;
                }
            }
            else if(!Flag1 && Flag2 && !Flag3 && !Flag4 && !FlagS)
            {
                if (second == num)
                {
                    Flag2 = false;
                    Flag3 = true;
                    num = 0;
                    continue;
                }

                if (list.Contains(rand))
                {
                    second_list.Add(rand);
                    list.Remove(rand);
                    num++;
                }
            }
            else if (!Flag1 && !Flag2 && Flag3 && !Flag4 && !FlagS)
            {
                if (thrid == num)
                {
                    Flag3 = false;
                    Flag4 = true;
                    num = 0;
                    continue;
                }

                if (list.Contains(rand))
                {
                    thrid_list.Add(rand);
                    list.Remove(rand);
                    num++;
                }
            }
            else if (!Flag1 && !Flag2 && !Flag3 && Flag4 && !FlagS)
            {
                if (fourth == num)
                {
                    Flag4 = false;
                    FlagS = true;
                    num = 0;
                    continue;
                }

                if (list.Contains(rand))
                {
                    fourth_list.Add(rand);
                    list.Remove(rand);
                    num++;
                }
            }
            else if (!Flag1 && !Flag2 && !Flag3 && !Flag4 && FlagS)
            {
                if (special == num)
                {
                    FlagS = false;
                    Flag1 = true;
                    num = 0;
                    break;
                }

                if (list.Contains(rand))
                {
                    special_list.Add(rand);
                    list.Remove(rand);
                    num++;
                }
            }
        }
    }

    public void OnPlayButton()
    {
        PlayerPrefs.SetInt("First", int.Parse(First_inputField.text));
        PlayerPrefs.SetInt("Second", int.Parse(Second_inputField.text));
        PlayerPrefs.SetInt("Thrid", int.Parse(Thrid_inputField.text));
        PlayerPrefs.SetInt("Fourth", int.Parse(Fourth_inputField.text));
        PlayerPrefs.SetInt("Special", int.Parse(Special_inputField.text));
        RandomNumber();
        ButtonFlag = true;
        Time.timeScale = 1f;
        string changeString = PlayerPrefs.GetInt("First") + "명";
        text_1.text = changeString;
        changeString = PlayerPrefs.GetInt("Second") + "명";
        text_2.text = changeString;
        changeString = PlayerPrefs.GetInt("Thrid") + "명";
        text_3.text = changeString;
        changeString = PlayerPrefs.GetInt("Fourth") + "명";
        text_4.text = changeString;
        changeString = PlayerPrefs.GetInt("Special") + "명";
        text_S.text = changeString;

    }

    public void OnDrawButton_1()
    {
        text_gift.text = "1등상\n" + PlayerPrefs.GetString("Gift_1");
        for (int i = 0; i < first_list.Count; i++)
        {
            GameObject spwanedObject = Instantiate(Card, gridParent);
            spwanedObject.name = first_list[i].ToString();
            spwanedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = first_list[i].ToString();
        }
    }

    public void OnDrawButton_2()
    {
        text_gift.text = "2등상\n"+ PlayerPrefs.GetString("Gift_2");
        for (int i = 0; i < second_list.Count; i++)
        {
            GameObject spwanedObject = Instantiate(Card, gridParent);
            spwanedObject.name = second_list[i].ToString();
            spwanedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = second_list[i].ToString();
        }
    }

    public void OnDrawButton_3()
    {
        text_gift.text = "3등상\n" + PlayerPrefs.GetString("Gift_3");
        for (int i = 0; i < thrid_list.Count; i++)
        {
            GameObject spwanedObject = Instantiate(Card, gridParent);
            spwanedObject.name = thrid_list[i].ToString();
            spwanedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = thrid_list[i].ToString();
        }
    }

    public void OnDrawButton_4()
    {
        text_gift.text = "4등상\n" + PlayerPrefs.GetString("Gift_4");

        for (int i = 0; i < fourth_list.Count; i++)
        {
            GameObject spwanedObject = Instantiate(Card, gridParent);
            spwanedObject.name = fourth_list[i].ToString();
            spwanedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = fourth_list[i].ToString();
        }
    }

    public void OnDrawButton_S()
    {
        text_gift.text = "특별상\n" + PlayerPrefs.GetString("Gift_S");
        for (int i = 0; i < special_list.Count; i++)
        {
            GameObject spwanedObject = Instantiate(Card, gridParent);
            spwanedObject.name = special_list[i].ToString();
            spwanedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = special_list[i].ToString();
        }
    }

    public void OnBackButton()
    {
        int childCount = gridParent.childCount;

        for(int i = childCount - 1; i >= 0; i--)
        {
            Transform child = gridParent.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    public void OnMainButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnAllOpenButton()
    {
        StartCoroutine(LoopWaitDelay());
    }

    private IEnumerator LoopWaitDelay()
    {
        int childCount = gridParent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gridParent.GetChild(i).GetComponent<Card>().OnAllOpen();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeList(GameObject card)
    {
        int index;
        if (first_list.Contains(int.Parse(card.name)))
        {
            index = first_list.IndexOf(int.Parse(card.name));
            while (true)
            {
                if(list.Count == 0)
                {
                    first_list[index] = 0;
                    card.name = first_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = first_list[index].ToString();
                    break;
                }

                int rand = UnityEngine.Random.Range(1, count + 1);
                if (list.Contains(rand))
                {
                    first_list[index] = rand;
                    list.Remove(rand);
                    card.name = first_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = first_list[index].ToString();
                    break;
                }
            }
        }else if (second_list.Contains(int.Parse(card.name))){
            index = second_list.IndexOf(int.Parse(card.name));
            while (true)
            {
                if (list.Count == 0)
                {
                    second_list[index] = 0;
                    card.name = second_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = second_list[index].ToString();
                    break;
                }

                int rand = UnityEngine.Random.Range(1, count + 1);
                if (list.Contains(rand))
                {
                    second_list[index] = rand;
                    list.Remove(rand);
                    card.name = second_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = second_list[index].ToString();
                    break;
                }
            }
        }else if (thrid_list.Contains(int.Parse(card.name))){
            index = thrid_list.IndexOf(int.Parse(card.name));
            while (true)
            {
                if (list.Count == 0)
                {
                    thrid_list[index] = 0;
                    card.name = thrid_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = thrid_list[index].ToString();
                    break;
                }

                int rand = UnityEngine.Random.Range(1, count + 1);
                if (list.Contains(rand))
                {
                    thrid_list[index] = rand;
                    list.Remove(rand);
                    card.name = thrid_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = thrid_list[index].ToString();
                    break;
                }
            }
        }else if (fourth_list.Contains(int.Parse(card.name))){
            index = fourth_list.IndexOf(int.Parse(card.name));
            while (true)
            {
                if (list.Count == 0)
                {
                    fourth_list[index] = 0;
                    card.name = fourth_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = fourth_list[index].ToString();
                    break;
                }

                int rand = UnityEngine.Random.Range(1, count + 1);
                if (list.Contains(rand))
                {
                    fourth_list[index] = rand;
                    list.Remove(rand);
                    card.name = fourth_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = fourth_list[index].ToString();
                    break;
                }
            }
        }
        else if (special_list.Contains(int.Parse(card.name))){
            index = special_list.IndexOf(int.Parse(card.name));
            while (true)
            {
                if (list.Count == 0)
                {
                    special_list[index] = 0;
                    card.name = special_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = special_list[index].ToString();
                    break;
                }

                int rand = UnityEngine.Random.Range(1, count + 1);
                if (list.Contains(rand))
                {
                    special_list[index] = rand;
                    list.Remove(rand);
                    card.name = special_list[index].ToString();
                    card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = special_list[index].ToString();
                    break;
                }
            }
        }
    }
}
