using UnityEngine;
using TMPro;

public class CharacterLimit : MonoBehaviour
{
    public int maxCharacters = 25;

    void Start()
    {
        TMP_InputField tmpInputField = GetComponent<TMP_InputField>();

        if (tmpInputField != null)
        {
            tmpInputField.characterLimit = maxCharacters;
        }
        else
        {
            Debug.LogError("CharacterLimit script requires a TMP_InputField component. Make sure it is attached to the correct GameObject.");
        }
    }
}
