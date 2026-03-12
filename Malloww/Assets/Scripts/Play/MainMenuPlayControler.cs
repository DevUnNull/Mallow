using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayControler : MonoBehaviour
{
    public string gameplaySceneName = "StartScene";  // Đặt tên scene gameplay

    // Hàm gọi khi nhấn nút Play
    public void OnOutButton()
    {
        Debug.Log("▶ Thoat Game");
        SceneManager.LoadScene(gameplaySceneName);
        Time.timeScale = 1.0f;
    }

    public void OnReplayGame()
    {
        UiPlayManager.instance.ReplayGame();
        Time.timeScale = 1f;
    }
    public void OnSettingButton()
    {
        Debug.Log("⚙️ Mở cài đặt");
        UiPlayManager.instance.ShowSettingUI();
        Time.timeScale = 0f;
    }
    public void OnCloseSettingButton()
    {
        Debug.Log("🚪 Đóng cài đặt");
        UiPlayManager.instance.CloseSettingUI();
        Time.timeScale = 1f;
    }

    public void OnQuitPlayButton()
    {
        Debug.Log("❌ Thoát tran game");
    }
}
