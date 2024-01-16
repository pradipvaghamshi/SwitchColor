using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite MusicOnImg, MusicOffImg, SoundOnImg, SoundOffImg;
    [SerializeField]
    AudioClip MusicClip, SoundClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        SoundImgManager();
    }
    public void SoundImgManager()       //sound manager
    {
        SoundClickPlay();
        if (CommanScript.Instance.Sound)
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
            CommanScript.Instance.Sound = false;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
            CommanScript.Instance.Sound = true;
        }
    }
    public void MusicImgManager()       //music manager
    {
        SoundClickPlay();
        if (CommanScript.Instance.Music)
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            MusicBtn.GetComponent<Image>().sprite = MusicOffImg;
            CommanScript.Instance.Music = false;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            MusicBtn.GetComponent<Image>().sprite = MusicOnImg;
            CommanScript.Instance.Music = true;
        }
    }
    public void SoundClickPlay()        //sound play click 
    {
        CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }

    public void SoundSet()     //sound set
    {
        if (CommanScript.Instance.Sound)
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
        }
    }

    public void MusicSet()     //music set
    {

        if (CommanScript.Instance.Music)
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            MusicBtn.GetComponent<Image>().sprite = MusicOnImg;
        }
        else
        {
            CommanScript.Instance.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            MusicBtn.GetComponent<Image>().sprite = MusicOffImg;
        }
    }
}
