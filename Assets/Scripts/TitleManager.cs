using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public InputField _inputField;
    public Button _soloButton;
    public Text _descriptionText;
    public AudioClip sound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _descriptionText.gameObject.SetActive(false);
        
        _soloButton.onClick.AddListener(SoloButtonClick);

        audioSource = GetComponent<AudioSource>();
    }

    private void SoloButtonClick()
    {
       string inputText = _inputField.text;
       UserName.userName = inputText;
       if(string.IsNullOrEmpty(inputText))
       {
        _descriptionText.gameObject.SetActive(true);
       }
       else
       {
        _descriptionText.gameObject.SetActive(false);
        audioSource.PlayOneShot(sound);
        SceneManager.LoadScene("SoloScene");
       }
    }

 
}
