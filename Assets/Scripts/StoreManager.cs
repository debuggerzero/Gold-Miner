using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Canvas StoreCanvas;
    // Start is called before the first frame update
    void Start()
    {
        StoreCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
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
