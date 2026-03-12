using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public string gameplaySceneName = "Gameplay";  // Đặt tên scene gameplay
    public int TimeWait = 2;
    // Hàm gọi khi nhấn nút Play
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void OnPlayButton()
    {
        Debug.Log("▶ Bắt đầu game");
        StartCoroutine(WaitAnimationLoad());
    }

    IEnumerator WaitAnimationLoad()
    {
        anim.SetBool("IsNextScene", true);

        yield return new WaitForSeconds(TimeWait);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameplaySceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        anim.SetBool("IsNewScene", true);
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
