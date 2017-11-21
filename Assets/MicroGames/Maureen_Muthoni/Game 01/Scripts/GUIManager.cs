using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MaureenMuthoniGame1
{
    public class GUIManager : MonoBehaviour
    {
        public Text winScreen, loseScreen;
        void Awake()
        {
            winScreen.gameObject.SetActive(false);
            loseScreen.gameObject.SetActive(false);
        }
        // Update is called once per frame
        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Water")
            {
                loseScreen.gameObject.SetActive(true);
                winScreen.gameObject.SetActive(false);
            }
            if (col.tag == "House")
            {
                winScreen.gameObject.SetActive(true);
                loseScreen.gameObject.SetActive(false);
            }
        }


    }
}
