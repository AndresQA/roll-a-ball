using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Controler : MonoBehaviour
{

    bool paused = false;

    public GameObject panelPause;
    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(paused);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausarJuego(){
        paused =! paused;

        if(paused){
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }else{
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
        panelPause.SetActive(paused);
    }

    public void ReiniciarJuego(){
        SceneManager.LoadScene(0);
        PausarJuego();
    }

}
