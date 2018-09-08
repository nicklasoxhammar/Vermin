
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    [SerializeField] Sprite soundOnSprite;
    [SerializeField] Sprite muteSprite;

    bool isMuted = false;

    void Start() {

        if (!PlayerPrefs.HasKey("sound")) {
            PlayerPrefs.SetInt("sound", 1);
        }

        SetSoundValue();

    }


    public void OnOffSound() {

        //if sound is on, then turn off - and vice versa
        PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound") * -1);
        SetSoundValue();
    }


    private void SetSoundValue() {


        if (PlayerPrefs.GetInt("sound") == 1) {
            isMuted = false;
            gameObject.GetComponent<Image>().sprite = soundOnSprite;
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("sound") == -1) {
            isMuted = true;
            gameObject.GetComponent<Image>().sprite = muteSprite;
            AudioListener.volume = 0;
        }


    }



}
