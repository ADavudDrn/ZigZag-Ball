using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform takipEdilecekNesne;
    Vector3 fark;
    void Start()
    {
        fark = transform.position - takipEdilecekNesne.position;
    }
    void LateUpdate()
    {
        if(Player.dustuMu == false)
        {
            transform.position = takipEdilecekNesne.position + fark;
        }
    }
}
