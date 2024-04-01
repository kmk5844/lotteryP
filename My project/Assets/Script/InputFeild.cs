using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NumericInputFilter : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        inputField.onValidateInput += ValidateNumericInput;

    }

    private char ValidateNumericInput(string text, int charIndex, char addedChar)
    {
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }
}
