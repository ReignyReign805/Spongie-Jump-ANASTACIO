using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveButton5 : MonoBehaviour
{
    public TMP_InputField usernameInput5;
    public GameObject addBtnBG5;
    public GameObject usernameTextObject5;
    public SelectUserPage selectUserPage5;

    void Start()
    {
        // Load and display the username when the scene starts
        LoadAndDisplayUsername();

        // Listen for the event when the username changes
        PlayerDataController.Instance.OnUsernameChanged5.AddListener(LoadAndDisplayUsername);
    }

    public void SaveUsername()
    {
        SaveUsernameForSet(usernameInput5, addBtnBG5, usernameTextObject5, selectUserPage5);
    }

    public void RemovePlayer()
    {
        // Call the method in SelectUserPage to remove the current player
        if (selectUserPage5 != null)
        {
            selectUserPage5.RemoveCurrentPlayer5();
        }

        // Show AddBtnBG after removing the player
        Image addBtnBGImage = addBtnBG5.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = true;
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG5.");
        }
    }

    // Helper method to load and display the username
    private void LoadAndDisplayUsername()
    {
        // Load the username using PlayerDataController
        string loadedUsername = PlayerDataController.Instance.PlayerUsername5;

        // Display the loaded username in the UI
        if (usernameTextObject5 != null)
        {
            TMP_Text usernameText = usernameTextObject5.GetComponent<TMP_Text>();
            if (usernameText != null)
            {
                usernameText.text = loadedUsername;
            }
            else
            {
                Debug.LogError("TMP_Text component not found in the children of usernameTextObject5.");
            }
        }

        // Show or hide AddBtnBG based on the presence of a username
        Image addBtnBGImage = addBtnBG5.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = string.IsNullOrEmpty(loadedUsername);
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG5.");
        }
    }

    // Helper method to save the username for a given set of UI elements
    private void SaveUsernameForSet(TMP_InputField inputField, GameObject addBtn, GameObject usernameTextObj, SelectUserPage selectPage)
    {
        if (inputField != null && addBtn != null && usernameTextObj != null && selectPage != null)
        {
            string enteredUsername = inputField.text;

            // Save the username using PlayerDataController
            PlayerDataController.Instance.PlayerUsername5 = enteredUsername;

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
            selectPage.ShowRemovePlayerBtn5();
        }
        else
        {
            Debug.LogError("InputField, addBtn, usernameTextObj, or selectPage is not assigned in the Inspector.");
        }
    }
}
