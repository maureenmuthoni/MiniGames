using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





namespace StirlingMulvey
{
    public class GlobalGameManager : MonoBehaviour
    {
        public static string verb = "GO!";
        public static float gameSpeed = 1;
        public static int level = 0;
        public static bool gameWon = false;
        public static bool gameActive = false;
        public static int selectedScene = 0;

        // Use this for initialization
        public static void ActivateSelectedScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(selectedScene));
        }
    }
}
