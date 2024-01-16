 using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public string CurrentColor;
    public float jumpforce = 10f;
    public GameObject[] obsticle;
    public GameObject ColorChanger;
    public Rigidbody2D circle;
    public SpriteRenderer sr;
    public Color Blue;
    public Color Yellow;
    public Color Pink;
    public Color Purple;
    public static int score = 0;
    public TextMeshProUGUI scoretext;
    [SerializeField]
    Button MusicBtn, SoundBtn;
    [SerializeField]
    Sprite MusicOnImg, MusicOffImg, SoundOnImg, SoundOffImg;
    [SerializeField]
    AudioClip MusicClip, SoundClip;
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Work");
             circle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            circle.velocity = Vector2. up * jumpforce; 
            scoretext.text = score.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Scored")
        {
            score++;
            Destroy(collision.gameObject);
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
                Instantiate(obsticle[0], new Vector2(transform.position.x, transform.position.y + 8f), transform.rotation);
            else
                Instantiate(obsticle[1], new Vector2(transform.position.x, transform.position.y + 8f), transform.rotation);
            return;
        }
        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            Instantiate(ColorChanger, new Vector2(transform.position.x, transform.position.y + 8f), transform.rotation);
            return;
        }
        if (collision.tag != CurrentColor)
        {
            Debug.Log("You are die!!!!!!!!!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }    }

    void SetRandomColor()
    {
        int rand = Random.Range(0,4);
        switch (rand)
        {
            case 0:
                CurrentColor = "Blue";
                sr.color = Blue;
                break;
            case 1:
                CurrentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                CurrentColor = "Pink";
                sr.color = Pink;
                break;
            case 3:
                CurrentColor = "Purple";
                sr.color = Purple;
                break;
        }
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
