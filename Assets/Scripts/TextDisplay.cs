using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void SetValue(string value)
    {
        text.text = value;
    }

    public void ResetValue()
    {
        text.text = "";
    }
}
