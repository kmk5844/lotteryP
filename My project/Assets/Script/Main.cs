using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public TMP_InputField numField;
    public TMP_InputField gift1;
    public TMP_InputField gift2;
    public TMP_InputField gift3;
    public TMP_InputField gift4;
    public TMP_InputField giftS;


    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {

    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("Count", int.Parse(numField.text));
        SceneManager.LoadScene("Play");
    }

    public void OnSettingClick()
    {
        PlayerPrefs.SetString("Gift_1", gift1.text);
        PlayerPrefs.SetString("Gift_2", gift2.text);
        PlayerPrefs.SetString("Gift_3", gift3.text);
        PlayerPrefs.SetString("Gift_4", gift4.text);
        PlayerPrefs.SetString("Gift_S", giftS.text);
    }

    public void OnDeleteButton()
    {
        PlayerPrefs.DeleteAll();
    }
}
