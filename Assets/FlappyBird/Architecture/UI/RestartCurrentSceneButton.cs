using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

namespace Architecture.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartCurrentSceneButton : MonoBehaviour
    {
        private Button m_button;

        private void Awake() {
            m_button = GetComponent<Button>();
            var curScene = SceneManager.GetActiveScene().name;
            m_button.onClick.AddListener(() => SceneManager.LoadScene(curScene));
        }

    }
}