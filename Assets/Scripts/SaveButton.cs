using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveButton : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public GameObject addBtnBG;
    public GameObject usernameTextObject;
    public SelectUserPage selectUserPage;

    void Start()
    {
        // Load and display the username when the scene starts
        LoadAndDisplayUsername();

        // Listen for the event when the username changes
        PlayerDataController.Instance.OnUsernameChanged.AddListener(LoadAndDisplayUsername);
    }

    public void SaveUsername()
    {
        if (usernameInput != null && addBtnBG != null && usernameTextObject != null && selectUserPage != null)
        {
            string enteredUsername = usernameInput.text;

            // Save the username using PlayerDataController
            PlayerDataController.Instance.PlayerUsername = enteredUsername;

            // Hide AddBtnBG
            Image addBtnBGImage = addBtnBG.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = false;
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddBtnBG.");
            }

            // Show Username Text
            TMP_Text usernameText = usernameTextObject.GetComponent<TMP_Text>();
            if (usernameText != null)
            {
                usernameText.text = enteredUsername;
            }
            else
            {
                Debug.LogError("TMP_Text component not found in the children of usernameTextObject.");
            }

            // Show RemovePlayerBtn in SelectUserPage
            selectUserPage.ShowRemovePlayerBtn();
        }
        else
        {
            Debug.LogError("usernameInput, addBtnBG, usernameTextObject, or selectUserPage is not assigned in the Inspector.");
        }
    }

    public void RemovePlayer()
    {
        // Call the method in SelectUserPage to remove the current player
        if (selectUserPage != null)
        {
            selectUserPage.RemoveCurrentPlayer();
        }

        // Show AddBtnBG after removing the player
        Image addBtnBGImage = addBtnBG.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = true;
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG.");
        }
    }

    // Helper method to load and display the username
    private void LoadAndDisplayUsername()
    {
        // Load the username using PlayerDataController
        string loadedUsername = PlayerDataController.Instance.PlayerUsername;

        // Display the loaded username in the UI
        if (usernameTextObject != null)
        {
            TMP_Text usernameText = usernameTextObject.GetComponent<TMP_Text>();
            if (usernameText != null)
            {
                usernameText.text = loadedUsername;
            }
            else
            {
                Debug.LogError("TMP_Text component not found in the children of usernameTextObject.");
            }
        }

        // Show or hide AddBtnBG based on the presence of a username
        Image addBtnBGImage = addBtnBG.GetComponent<Image>();
        if (addBtnBGImage != null)
        {
            addBtnBGImage.enabled = string.IsNullOrEmpty(loadedUsername);
        }
        else
        {
            Debug.LogError("Image component not found in the children of AddBtnBG.");
        }
    }
}
