using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StirlingMulvey
{
    public class MicroMusicManager : MonoBehaviour {
        AudioSource myAudi;
        // Use this for initialization
        void Start() {
            myAudi = GetComponent<AudioSource>();
            myAudi.pitch = GlobalGameManager.gameSpeed;
            StartCoroutine(waitForGameStart());
        }

        IEnumerator waitForGameStart()
        {
            while (!GlobalGameManager.gameActive)
            {
                yield return null;
            }
            myAudi.Play();
        }
    }
}
