using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text txtFin;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(staticValues.winner == 0)
        {
            txtFin.text = "Perdiste :(";
            txtFin.color = Color.red;
            txtFin.enabled = true;
        }
        else if (staticValues.winner == 1)
        {
            txtFin.text = "Ganaste!!";
            txtFin.color = Color.green;
            txtFin.enabled = true;
        }
        else
        {
            txtFin.enabled = false;
        }
    }


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
}
