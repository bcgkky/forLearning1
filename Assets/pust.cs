using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pust : MonoBehaviour
{
    int saglik = 100;
    public GameObject forSkor;
    int skor=15;

    
    public void CanDurum(int darbe)
    {
        if (saglik <= 0)
        {
            Destroy(gameObject);
            forSkor.gameObject.GetComponent<lavuk>().SkorYaz(skor);

        }
        else
        {
            saglik -= darbe;
        }
    }
}
