using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectUserPage : MonoBehaviour
{
    // UI elements for the first player
    public GameObject addPlayerBtn;
    public GameObject removePlayerBtn;
    public TMP_Text usernameText;

    // UI elements for the second player
    public GameObject addPlayerBtn2;
    public GameObject removePlayerBtn2;
    public TMP_Text usernameText2;

    // UI elements for the third player
    public GameObject addPlayerBtn3;
    public GameObject removePlayerBtn3;
    public TMP_Text usernameText3;

    // UI elements for the fourth player
    public GameObject addPlayerBtn4;
    public GameObject removePlayerBtn4;
    public TMP_Text usernameText4;

    // UI elements for the fifth player
    public GameObject addPlayerBtn5;
    public GameObject removePlayerBtn5;
    public TMP_Text usernameText5;

    void Start()
    {
        // Initially hide the RemovePlayerBtn for all players
        if (removePlayerBtn != null)
        {
            removePlayerBtn.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn not assigned in the Inspector.");
        }

        if (removePlayerBtn2 != null)
        {
            removePlayerBtn2.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn2 not assigned in the Inspector.");
        }

        if (removePlayerBtn3 != null)
        {
            removePlayerBtn3.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn3 not assigned in the Inspector.");
        }

        if (removePlayerBtn4 != null)
        {
            removePlayerBtn4.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn4 not assigned in the Inspector.");
        }

        if (removePlayerBtn5 != null)
        {
            removePlayerBtn5.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn5 not assigned in the Inspector.");
        }

        // Update UI with the current saved username for all players
        UpdateUsernameUI();
        UpdateUsernameUI2();
        UpdateUsernameUI3();
        UpdateUsernameUI4();
        UpdateUsernameUI5();
    }

    // Call this method after adding a user to show the RemovePlayerBtn
    public void ShowRemovePlayerBtn()
    {
        if (removePlayerBtn != null)
        {
            removePlayerBtn.SetActive(true);

            // Also hide the addPlayerBtn when the removePlayerBtn is shown
            if (addPlayerBtn != null)
            {
                addPlayerBtn.SetActive(false);
            }
            else
            {
                Debug.LogError("AddPlayerBtn not assigned in the Inspector.");
            }

            // Reset the best score for the new user
            PlayerPrefs.DeleteKey("bestScore");
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("RemovePlayerBtn not assigned in the Inspector.");
        }
    }

    // Call this method after adding a user to show the RemovePlayerBtn for the second player
    public void ShowRemovePlayerBtn2()
    {
        if (removePlayerBtn2 != null)
        {
            removePlayerBtn2.SetActive(true);

            // Also hide the addPlayerBtn2 when the removePlayerBtn2 is shown
            if (addPlayerBtn2 != null)
            {
                addPlayerBtn2.SetActive(false);
            }
            else
            {
                Debug.LogError("AddPlayerBtn2 not assigned in the Inspector.");
            }

            // Reset the best score for the new user
            PlayerPrefs.DeleteKey("bestScore2");
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("RemovePlayerBtn2 not assigned in the Inspector.");
        }
    }

    // Call this method after adding a user to show the RemovePlayerBtn for the third player
    public void ShowRemovePlayerBtn3()
    {
        if (removePlayerBtn3 != null)
        {
            removePlayerBtn3.SetActive(true);

            // Also hide the addPlayerBtn3 when the removePlayerBtn3 is shown
            if (addPlayerBtn3 != null)
            {
                addPlayerBtn3.SetActive(false);
            }
            else
            {
                Debug.LogError("AddPlayerBtn3 not assigned in the Inspector.");
            }

            // Reset the best score for the new user
            PlayerPrefs.DeleteKey("bestScore3");
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("RemovePlayerBtn3 not assigned in the Inspector.");
        }
    }

    // Call this method to remove the current player
    public void RemoveCurrentPlayer()
    {
        string clickedUsername = string.Empty;

        if (usernameText != null)
        {
            // Save the username before clearing PlayerPrefs
            clickedUsername = usernameText.text;

            // Log when the username is clicked
            Debug.Log("Username clicked: " + clickedUsername);
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText.");
        }

        // Show AddBtnBG
        if (addPlayerBtn != null)
        {
            Image addBtnBGImage = addPlayerBtn.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = true;

                // Also show the addPlayerBtn when removing the player
                addPlayerBtn.SetActive(true);
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddPlayerBtn.");
            }
        }
        else
        {
            Debug.LogError("AddPlayerBtn not assigned in the Inspector.");
        }

        // Clear the TMP text
        if (usernameText != null)
        {
            usernameText.text = string.Empty;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText.");
        }

        // Hide RemovePlayerBtn
        if (removePlayerBtn != null)
        {
            removePlayerBtn.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn not assigned in the Inspector.");
        }

        // Clear PlayerPrefs data
        PlayerPrefs.DeleteKey("PlayerUsername");
        PlayerPrefs.Save();
    }

    // Call this method to remove the current player for the second player
    public void RemoveCurrentPlayer2()
    {
        string clickedUsername = string.Empty;

        if (usernameText2 != null)
        {
            // Save the username before clearing PlayerPrefs
            clickedUsername = usernameText2.text;

            // Log when the username is clicked
            Debug.Log("Username clicked: " + clickedUsername);
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText2.");
        }

        // Show AddBtnBG for the second player
        if (addPlayerBtn2 != null)
        {
            Image addBtnBGImage = addPlayerBtn2.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = true;

                // Also show the addPlayerBtn2 when removing the player
                addPlayerBtn2.SetActive(true);
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddPlayerBtn2.");
            }
        }
        else
        {
            Debug.LogError("AddPlayerBtn2 not assigned in the Inspector.");
        }

        // Clear the TMP text for the second player
        if (usernameText2 != null)
        {
            usernameText2.text = string.Empty;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText2.");
        }

        // Hide RemovePlayerBtn for the second player
        if (removePlayerBtn2 != null)
        {
            removePlayerBtn2.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn2 not assigned in the Inspector.");
        }

        // Clear PlayerPrefs data for the second player
        PlayerPrefs.DeleteKey("PlayerUsername2");
        PlayerPrefs.Save();
    }

    // Call this method to remove the current player for the third player
    public void RemoveCurrentPlayer3()
    {
        string clickedUsername = string.Empty;

        if (usernameText3 != null)
        {
            // Save the username before clearing PlayerPrefs
            clickedUsername = usernameText3.text;

            // Log when the username is clicked
            Debug.Log("Username clicked: " + clickedUsername);
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText3.");
        }

        // Show AddBtnBG for the third player
        if (addPlayerBtn3 != null)
        {
            Image addBtnBGImage = addPlayerBtn3.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = true;

                // Also show the addPlayerBtn3 when removing the player
                addPlayerBtn3.SetActive(true);
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddPlayerBtn3.");
            }
        }
        else
        {
            Debug.LogError("AddPlayerBtn3 not assigned in the Inspector.");
        }

        // Clear the TMP text for the third player
        if (usernameText3 != null)
        {
            usernameText3.text = string.Empty;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText3.");
        }

        // Hide RemovePlayerBtn for the third player
        if (removePlayerBtn3 != null)
        {
            removePlayerBtn3.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn3 not assigned in the Inspector.");
        }

        // Clear PlayerPrefs data for the third player
        PlayerPrefs.DeleteKey("PlayerUsername3");
        PlayerPrefs.Save();
    }

    // Call this method after adding a user to show the RemovePlayerBtn for the fourth player
    public void ShowRemovePlayerBtn4()
    {
        if (removePlayerBtn4 != null)
        {
            removePlayerBtn4.SetActive(true);

            // Also hide the addPlayerBtn4 when the removePlayerBtn4 is shown
            if (addPlayerBtn4 != null)
            {
                addPlayerBtn4.SetActive(false);
            }
            else
            {
                Debug.LogError("AddPlayerBtn4 not assigned in the Inspector.");
            }

            // Reset the best score for the new user
            PlayerPrefs.DeleteKey("bestScore4");
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("RemovePlayerBtn4 not assigned in the Inspector.");
        }
    }

    // Call this method to remove the current player for the fourth player
    public void RemoveCurrentPlayer4()
    {
        string clickedUsername = string.Empty;

        if (usernameText4 != null)
        {
            // Save the username before clearing PlayerPrefs
            clickedUsername = usernameText4.text;

            // Log when the username is clicked
            Debug.Log("Username clicked: " + clickedUsername);
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText4.");
        }

        // Show AddBtnBG for the fourth player
        if (addPlayerBtn4 != null)
        {
            Image addBtnBGImage = addPlayerBtn4.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = true;

                // Also show the addPlayerBtn4 when removing the player
                addPlayerBtn4.SetActive(true);
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddPlayerBtn4.");
            }
        }
        else
        {
            Debug.LogError("AddPlayerBtn4 not assigned in the Inspector.");
        }

        // Clear the TMP text for the fourth player
        if (usernameText4 != null)
        {
            usernameText4.text = string.Empty;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText4.");
        }

        // Hide RemovePlayerBtn for the fourth player
        if (removePlayerBtn4 != null)
        {
            removePlayerBtn4.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn4 not assigned in the Inspector.");
        }

        // Clear PlayerPrefs data for the fourth player
        PlayerPrefs.DeleteKey("PlayerUsername4");
        PlayerPrefs.Save();
    }

    // Call this method after adding a user to show the RemovePlayerBtn for the fifth player
    public void ShowRemovePlayerBtn5()
    {
        if (removePlayerBtn5 != null)
        {
            removePlayerBtn5.SetActive(true);

            // Also hide the addPlayerBtn5 when the removePlayerBtn5 is shown
            if (addPlayerBtn5 != null)
            {
                addPlayerBtn5.SetActive(false);
            }
            else
            {
                Debug.LogError("AddPlayerBtn5 not assigned in the Inspector.");
            }

            // Reset the best score for the new user
            PlayerPrefs.DeleteKey("bestScore5");
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("RemovePlayerBtn5 not assigned in the Inspector.");
        }
    }

    // Call this method to remove the current player for the fifth player
    public void RemoveCurrentPlayer5()
    {
        string clickedUsername = string.Empty;

        if (usernameText5 != null)
        {
            // Save the username before clearing PlayerPrefs
            clickedUsername = usernameText5.text;

            // Log when the username is clicked
            Debug.Log("Username clicked: " + clickedUsername);
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText5.");
        }

        // Show AddBtnBG for the fifth player
        if (addPlayerBtn5 != null)
        {
            Image addBtnBGImage = addPlayerBtn5.GetComponent<Image>();
            if (addBtnBGImage != null)
            {
                addBtnBGImage.enabled = true;

                // Also show the addPlayerBtn5 when removing the player
                addPlayerBtn5.SetActive(true);
            }
            else
            {
                Debug.LogError("Image component not found in the children of AddPlayerBtn5.");
            }
        }
        else
        {
            Debug.LogError("AddPlayerBtn5 not assigned in the Inspector.");
        }

        // Clear the TMP text for the fifth player
        if (usernameText5 != null)
        {
            usernameText5.text = string.Empty;
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText5.");
        }

        // Hide RemovePlayerBtn for the fifth player
        if (removePlayerBtn5 != null)
        {
            removePlayerBtn5.SetActive(false);
        }
        else
        {
            Debug.LogError("RemovePlayerBtn5 not assigned in the Inspector.");
        }

        // Clear PlayerPrefs data for the fifth player
        PlayerPrefs.DeleteKey("PlayerUsername5");
        PlayerPrefs.Save();
    }

    // Helper method to update UI with the current saved username
    private void UpdateUsernameUI()
    {
        if (usernameText != null)
        {
            // Load the username using PlayerDataController
            string loadedUsername = PlayerDataController.Instance.PlayerUsername;
            usernameText.text = loadedUsername;

            // Toggle visibility of addPlayerBtn based on the presence of a username
            if (addPlayerBtn != null)
            {
                addPlayerBtn.SetActive(string.IsNullOrEmpty(loadedUsername));
            }
            else
            {
                Debug.LogError("AddPlayerBtn not assigned in the Inspector.");
            }

            // Toggle visibility of removePlayerBtn based on the presence of a username
            if (removePlayerBtn != null)
            {
                removePlayerBtn.SetActive(!string.IsNullOrEmpty(loadedUsername));
            }
            else
            {
                Debug.LogError("RemovePlayerBtn not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText.");
        }
    }

    // Helper method to update UI with the current saved username for the second player
    private void UpdateUsernameUI2()
    {
        if (usernameText2 != null)
        {
            // Load the username using PlayerDataController for the second player
            string loadedUsername2 = PlayerDataController.Instance.PlayerUsername2;
            usernameText2.text = loadedUsername2;

            // Toggle visibility of addPlayerBtn2 based on the presence of a username
            if (addPlayerBtn2 != null)
            {
                addPlayerBtn2.SetActive(string.IsNullOrEmpty(loadedUsername2));
            }
            else
            {
                Debug.LogError("AddPlayerBtn2 not assigned in the Inspector.");
            }

            // Toggle visibility of removePlayerBtn2 based on the presence of a username
            if (removePlayerBtn2 != null)
            {
                removePlayerBtn2.SetActive(!string.IsNullOrEmpty(loadedUsername2));
            }
            else
            {
                Debug.LogError("RemovePlayerBtn2 not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText2.");
        }
    }

    // Helper method to update UI with the current saved username for the third player
    private void UpdateUsernameUI3()
    {
        if (usernameText3 != null)
        {
            // Load the username using PlayerDataController for the third player
            string loadedUsername3 = PlayerDataController.Instance.PlayerUsername3;
            usernameText3.text = loadedUsername3;

            // Toggle visibility of addPlayerBtn3 based on the presence of a username
            if (addPlayerBtn3 != null)
            {
                addPlayerBtn3.SetActive(string.IsNullOrEmpty(loadedUsername3));
            }
            else
            {
                Debug.LogError("AddPlayerBtn3 not assigned in the Inspector.");
            }

            // Toggle visibility of removePlayerBtn3 based on the presence of a username
            if (removePlayerBtn3 != null)
            {
                removePlayerBtn3.SetActive(!string.IsNullOrEmpty(loadedUsername3));
            }
            else
            {
                Debug.LogError("RemovePlayerBtn3 not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText3.");
        }
    }

    // Helper method to update UI with the current saved username for all players
    private void UpdateUsernameUI4()
    {
        if (usernameText4 != null)
        {
            // Load the username using PlayerDataController for the fifth player
            string loadedUsername4 = PlayerDataController.Instance.PlayerUsername4;
            usernameText4.text = loadedUsername4;

            // Toggle visibility of addPlayerBtn4 based on the presence of a username
            if (addPlayerBtn4 != null)
            {
                addPlayerBtn4.SetActive(string.IsNullOrEmpty(loadedUsername4));
            }
            else
            {
                Debug.LogError("AddPlayerBtn5 not assigned in the Inspector.");
            }

            // Toggle visibility of removePlayerBtn5 based on the presence of a username
            if (removePlayerBtn4 != null)
            {
                removePlayerBtn4.SetActive(!string.IsNullOrEmpty(loadedUsername4));
            }
            else
            {
                Debug.LogError("RemovePlayerBtn5 not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText4.");
        }
    }

    // Helper method to update UI with the current saved username for all players
    private void UpdateUsernameUI5()
    {
        if (usernameText5 != null)
        {
            // Load the username using PlayerDataController for the fifth player
            string loadedUsername5 = PlayerDataController.Instance.PlayerUsername5;
            usernameText5.text = loadedUsername5;

            // Toggle visibility of addPlayerBtn5 based on the presence of a username
            if (addPlayerBtn5 != null)
            {
                addPlayerBtn5.SetActive(string.IsNullOrEmpty(loadedUsername5));
            }
            else
            {
                Debug.LogError("AddPlayerBtn5 not assigned in the Inspector.");
            }

            // Toggle visibility of removePlayerBtn5 based on the presence of a username
            if (removePlayerBtn5 != null)
            {
                removePlayerBtn5.SetActive(!string.IsNullOrEmpty(loadedUsername5));
            }
            else
            {
                Debug.LogError("RemovePlayerBtn5 not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("TMP_Text component not found in the children of usernameText5.");
        }
    }
}
