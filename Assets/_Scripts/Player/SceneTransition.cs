using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Player
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        [SerializeField] private bool transition;

        [SerializeField] private string sceneName;

        public void ChangeScene()
        {
            // get the state from the animator.
            anim.SetBool("transition", transition);
            SceneManager.LoadScene(sceneName);
        }
    }
}