using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string gameplaySceneName = "Gameplay";  // Đặt tên scene gameplay

    // Hàm gọi khi nhấn nút Play
    public void OnPlayButton()
    {
        Debug.Log("▶ Bắt đầu game");
        SceneManager.LoadScene(gameplaySceneName);
    }

    // Hàm gọi khi nhấn nút Store
    public void OnStoreButton()
    {
        Debug.Log("🛒 Mở cửa hàng");
        // Hiển thị UI Store hoặc chuyển scene Store (tuỳ game)
        // SceneManager.LoadScene("Store"); // Nếu tách thành scene riêng
        UIManager.instance.ShowStoreUI(); // Nếu dùng UI pop-up
    }

    // Hàm gọi khi nhấn nút Setting
    public void OnSettingButton()
    {
        Debug.Log("⚙️ Mở cài đặt");
        UIManager.instance.ShowSettingUI();  // Hoặc mở scene Setting
    }
    public void OnCloseStoreButton()
    {
        Debug.Log("🚪 Đóng cửa hàng");
        UIManager.instance.CloseStoreUI();
    }

    public void OnCloseSettingButton()
    {
        Debug.Log("🚪 Đóng cài đặt");
        UIManager.instance.CloseSettingUI();
    }
    // Tuỳ chọn: nút Quit game (chỉ áp dụng PC)
    public void OnQuitButton()
    {
        Debug.Log("❌ Thoát game");
        Application.Quit();
    }
}
