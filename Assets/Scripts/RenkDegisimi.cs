using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenkDegisimi : MonoBehaviour
{
    // Start is called before the first frame update
    public Color[] renkler;
    Color ilkRenk;
    Color ikinciRenk;
    int brRenk;
    public Material zeminMateriali;
    void Start()
    {
        brRenk = Random.Range(0, renkler.Length);
        zeminMateriali.color = renkler[brRenk];
        Camera.main.backgroundColor = renkler[brRenk];
        ikinciRenk = renkler[IkinciRenkBelirle()];
    }
    
    int IkinciRenkBelirle()
    {
        int ikRenk;
        if (renkler.Length <= 1)
        {
            ikRenk = brRenk;
            return ikRenk;
        }
        ikRenk = Random.Range(0, renkler.Length);
        while(ikRenk == brRenk)
        {
            ikRenk = Random.Range(0, renkler.Length);
        }
        return ikRenk;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Color fark = zeminMateriali.color - ikinciRenk;
        if(Mathf.Abs(fark.r)+ Mathf.Abs(fark.g)+ Mathf.Abs(fark.b) < 0.2f)
        {
            ikinciRenk = renkler[IkinciRenkBelirle()];
        }
        zeminMateriali.color = Color.Lerp(zeminMateriali.color, ikinciRenk, 0.009f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0045f);
    }
}
