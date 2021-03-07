using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminOlusturma : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sonZemin;
    void Start()
    {
        for(int i = 0; i < 35; i++)
        {
            ZeminOlustur();
        }
    }
    public void ZeminOlustur()
    {
        Vector3 yon;
        if(Random.Range(0, 2) == 0)
        {
            yon = Vector3.right;
        }
        else
        {
            yon = Vector3.back;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
    }
}
