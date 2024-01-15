using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveButton4 : MonoBehaviour
{
    public TMP_InputField usernameInput4;
    public GameObject addBtnBG4;
    public GameObject usernameTextObject4;
    public SelectUserPage selectUserPage4;

    void Start()
    {
        // Load and display the username when the scene starts
        LoadAndDisplayUsername();

        // Listen for the event when the username changes
        PlayerDataController.Instance.OnUsernameChanged4.AddListener(LoadAndDisplayUsername);
    }

    public void SaveUsername()
    {
        SaveUsernameForSet(usernameInput4, addBtnBG4, usernameTextObject4, selectUserPage4);
    }

    public void RemovePlayer()
    {
        // Call the method in SelectUserPage to remove the current player
        if (selectUserPage4 != null)
        {
            selectUserPage4.RemoveCurrentPlayer4();
        }

        // Show AddBtnBG after removing the player
        Image addBtnBGImage = addBtnBG4.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = true;
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG4.");
        }
    }

    // Helper method to load and display the username
    private void LoadAndDisplayUsername()
    {
        // Load the username using PlayerDataController
        string loadedUsername = PlayerDataController.Instance.PlayerUsername4;

        // Display the loaded username in the UI
        if (usernameTextObject4 != null)
        {
            TMP_Text usernameText = usernameTextObject4.GetComponent<TMP_Text>();
            if (usernameText != null)
            {
                usernameText.text = loadedUsername;
            }
            else
            {
                Debug.LogError("TMP_Text component not found in the children of usernameTextObject4.");
            }
        }

        // Show or hide AddBtnBG based on the presence of a username
        Image addBtnBGImage = addBtnBG4.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = string.IsNullOrEmpty(loadedUsername);
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG4.");
        }
    }

    // Helper method to save the username for a given set of UI elements
    private void SaveUsernameForSet(TMP_InputField inputField, GameObject addBtn, GameObject usernameTextObj, SelectUserPage selectPage)
    {
        if (inputField != null && addBtn != null && usernameTextObj != null && selectPage != null)
        {
            string enteredUsername = inputField.text;

            // Save the username using PlayerDataController
            PlayerDataController.Instance.PlayerUsername4 = enteredUsername;

            // Hide AddBtnBG
            Image addBtnBGImage = addBtn.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = false;
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddBtn.");
            }

            // Show Username Text
            TMP_Text usernameText = usernameTextObj.GetComponent<TMP_Text>();
            if (usernameText != null)
            {
                usernameText.text = enteredUsername;
            }
            else
            {
                Debug.LogError("TMP_Text component not found in the children of usernameTextObj.");
            }

            // Show RemovePlayerBtn in SelectUserPage
            selectPage.ShowRemovePlayerBtn4();
        }
        else
        {
            Debug.LogError("InputField, addBtn, usernameTextObj, or selectPage is not assigned in the Inspector.");
        }
    }
}
