using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class lavuk : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject namlu;
    public Text skor;
    int skorDeger;
    public GameObject bittiPanel;
    public GameObject forCross;
    public Text skorText;
    public Text timeText;
    public Text yuksekSureText;
    //float sure;
    public ParticleSystem part;
    public ParticleSystem temas;
    public Text banaMenu;
   

    void Start()
    {
        
    }

 
    void FixedUpdate()
    {

        float dik = Input.GetAxis("Horizontal");
        float yan = Input.GetAxis("Vertical");
        Vector3 vek = new Vector3(dik, 0f, yan);
        transform.Translate(vek * 5 * Time.deltaTime);

    }
    
    void Update()
    {
        fortextevent.sure += Time.deltaTime;
        timeText.text = "Süre : " + Mathf.Round(fortextevent.sure).ToString();
        

        int layerMask = 1 << 8;

        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && !forGameControl.esc)
        {
            if (Physics.Raycast(namlu.transform.position, transform.TransformDirection(Vector3.forward), out hit, 100, layerMask))
            {
                //Debug.DrawRay(namlu.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                //hit.rigidbody.AddForce(Vector3.forward * 600);
                hit.transform.gameObject.GetComponent<pust>().CanDurum(50);
                
                Instantiate(temas, hit.point, Quaternion.identity);

            }

            //else
            //Debug.DrawRay(namlu.transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.white);
            part.Play();
            
              
        }
        
        if (skorDeger == 180)
        {
            Bitti();
        }

    }

    public void SkorYaz(int skor1)
   {
        skorDeger += skor1;
        skor.text = skorDeger.ToString();
        
   }

    void Bitti()
    {
        bittiPanel.SetActive(true);
        forCross.SetActive(false);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("skor", skorDeger);
        PlayerPrefs.Save();
        skorText.text = "Skor : " + PlayerPrefs.GetInt("skor").ToString();
        PlayerPrefs.SetFloat("sure", Mathf.Round(fortextevent.sure));
        yuksekSureText.text = "Geçen Süre : " + PlayerPrefs.GetFloat("sure").ToString();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        banaMenu = GetComponent<Text>();
        banaMenu.fontSize += 2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        banaMenu = GetComponent<Text>();
        banaMenu.fontSize -= 2;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
}
