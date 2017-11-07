using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace StirlingMulvey
{
    public class HubCountdown : MonoBehaviour
    {
        float speedIncreaseScale = 1f;
        float maxGameSpeed = 3;
        public string[] countDownMessages;

        private Text countDownText;
        private int i = 0;

        // Use this for initialization
        void Start()
        {
            //locate and cache the UI countdown text used on the main door
            countDownText = transform.FindChild("DoorDisplay").FindChild("Countdown").GetComponent<Text>();
        }

        void CountDown()
        {
            //make the countdown text equal the string in the i position of the array and then increase it
            countDownText.text = countDownMessages[i];
            countDownMessages[3] = GlobalGameManager.verb;
            i++;
        }

        void ResetCount()
        {
            //reset i to 0, ready to count down again.
            i = 0;
            
        }

        void LoadLevel()
        {
            //select a random level between the second level in the build and the last
            GlobalGameManager.selectedScene = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            //load the selected level on top of the existing level
            SceneManager.LoadSceneAsync(GlobalGameManager.selectedScene, LoadSceneMode.Additive);
        }
        void UnloadLevel()
        {
            //unload the previously selected level
            SceneManager.UnloadSceneAsync(GlobalGameManager.selectedScene);
            //print a different message based on if the player has won
            if (GlobalGameManager.gameWon)
            {
                print("LEVEL UP!");
            }
            else
            {
                print("YOU SUCK AT GAMES!");
            }

            //set the game managers game speed to the current gamespeed + the increase scale, clamed to 0 and max speed
            GlobalGameManager.gameSpeed = Mathf.Clamp(GlobalGameManager.gameSpeed += speedIncreaseScale, 0, maxGameSpeed);
            //apply the global game speed to the timescale
            Time.timeScale = GlobalGameManager.gameSpeed;
        }

        void TogglePlaying()
        {
            GlobalGameManager.gameActive = !GlobalGameManager.gameActive;
        }
    }
}
