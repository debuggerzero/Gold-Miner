using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Canvas StoreCanvas;
    void Start()
    {
        StoreCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowtheStore()
    {
        StoreCanvas.gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        StoreCanvas.gameObject.SetActive(false);
    }
}
