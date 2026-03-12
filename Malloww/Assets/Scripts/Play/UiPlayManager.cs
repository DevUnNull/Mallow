using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiPlayManager : MonoBehaviour
{
    public static UiPlayManager instance;

    public GameObject GameOverPanel;
    public GameObject settingPanel;
    public SceneView sceneView;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ShowGameOverUI() => GameOverPanel.SetActive(true);
    public void CloseGameOverUI() => GameOverPanel.SetActive(false);

    public void ShowSettingUI() => settingPanel.SetActive(true);
    public void CloseSettingUI() => settingPanel.SetActive(false);

    public void ReplayGame()
    {
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f); // hoặc thêm hiệu ứng fade out ở đây
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
