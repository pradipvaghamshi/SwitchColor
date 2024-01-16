using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    [SerializeField]
    GameObject SettingPanal,pauspnl,GamePnl,QuitPanl;
    [SerializeField]
    GameObject IPanal;
    
    public void SettingOn()
    { 
        SettingPanal.SetActive(true);
    }
    public void SettingOff()
    {
        SettingPanal.SetActive(false);
    }
    public void ipanalon()
    { 
        IPanal.SetActive(true);
    }
    public void ipanaloff()
    {
        IPanal.SetActive(false);
    }
    public void pausGame()
    { 
        pauspnl.SetActive(true);
        GamePnl.SetActive(false);
        Time.timeScale = 0;
    }
    public void RemusGame()
    {
        pauspnl.SetActive(false);
        GamePnl.SetActive(true);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; 
    }

    public void quit()
    {
       Application.Quit();
    }
    public void QuitOn()
    {
      QuitPanl.SetActive(true);
    }
    public void QuitOff()
    {
        QuitPanl.SetActive(false);
    }
}
