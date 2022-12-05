using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Interface
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayButton()
        {
            // Load the first scene of the game
            SceneManager.LoadScene("Test", LoadSceneMode.Additive);
        }

        public void QuitButton()
        {
            // Check the Unity Editor
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        public void SettingsButton()
        {
            
        }
    }
}