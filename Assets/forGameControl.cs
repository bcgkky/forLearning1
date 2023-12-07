using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forGameControl : MonoBehaviour
{
    public GameObject[] menuPanel;
    public GameObject ustPanel;
    public static bool esc=false;
    bool ustMu = true;
    public GameObject lavuk;
    public GameObject[] icerikPaneller;
    public Slider forVolumeSlider;
    public Text volumeValue;

    
    
    void Start()
    {
        lavuk.GetComponent<AudioSource>().volume = .5f;
        forVolumeSlider.value = .5f;
        volumeValue.text = (forVolumeSlider.value * 100).ToString();
    }
    
    void Update()
    {
        lavuk.GetComponent<AudioSource>().volume = forVolumeSlider.value;
        volumeValue.text = Mathf.Round((forVolumeSlider.value * 100)).ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc = !esc;
            foreach (GameObject i in menuPanel)
            {
                i.SetActive(esc);

            }
            ustMu = !ustMu;
            ustPanel.SetActive(ustMu);
            if (esc) { Time.timeScale = 0; lavuk.GetComponent<AudioSource>().Pause(); }
            else { Time.timeScale = 1; lavuk.GetComponent<AudioSource>().UnPause(); }

            }
    }

    public void Butonlar(int index)
    {
        foreach (GameObject i in icerikPaneller)
        {
            i.SetActive(false);
        }
        
        icerikPaneller[index].SetActive(true);
    }
}
