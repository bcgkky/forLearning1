using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class forLoading : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;

    public void Loading(int sIndex)
    {
        Time.timeScale = 1;
        StartCoroutine(forLoadingg(sIndex));
        
    }

    IEnumerator forLoadingg (int forIndex)
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
