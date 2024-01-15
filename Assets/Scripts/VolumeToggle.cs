using UnityEngine;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    public Image volumeOnImage;
    public Image volumeOffImage;

    private bool isVolumeOn = true;

    void Start()
    {
        ToggleVolumeUI();
    }

    public void ToggleVolume()
    {
        isVolumeOn = !isVolumeOn;
        ToggleVolumeUI();
    }

    private void ToggleVolumeUI()
    {
        volumeOnImage.gameObject.SetActive(isVolumeOn);
        volumeOffImage.gameObject.SetActive(!isVolumeOn);
    }
}
