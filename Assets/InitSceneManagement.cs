using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitSceneManagement : MonoBehaviour
{
    [SerializeField] Button mStartGameButton;
    [SerializeField] Button mHowToPlayButton;
    [SerializeField] Button mCloseHowToPlay;

    [SerializeField] private GameObject mHowToPlayPanel;
    private void Awake()
    {
        mStartGameButton.onClick.AddListener(LoadScene);
        mHowToPlayButton.onClick.AddListener(() => mHowToPlayPanel.SetActive(true));
        mCloseHowToPlay.onClick.AddListener(() => mHowToPlayPanel.SetActive(false));
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        mHowToPlayPanel.SetActive(false);
    }
}
