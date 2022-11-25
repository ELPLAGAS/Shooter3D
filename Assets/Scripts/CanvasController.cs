using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text txtHP;
    public Text txtMunicion;
    public static CanvasController instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddTextHp(int vld)
    {
        txtHP.text = "HP: " + vld.ToString();
   
    
    
    }

    public void AddTextMunicion(int vld)
    {
        txtMunicion.text= "Municion: "+ vld.ToString();
    }

}
