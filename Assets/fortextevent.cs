using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fortextevent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    public static float sure;
    public Slider slider;
    public GameObject panel;
    void Start()
    {
        text = GetComponent<Text>();
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize += 2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize -= 2;
    }


    public void Loading(int sIndex)
    {
        Time.timeScale = 1;
        sure = 0;
        StartCoroutine(forLoadingg(sIndex));

    }

    IEnumerator forLoadingg(int forIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(forIndex);
        panel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
