using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject storePanel;
    public GameObject settingPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowStoreUI() => storePanel.SetActive(true);
    public void CloseStoreUI() => storePanel.SetActive(false);

    public void ShowSettingUI() => settingPanel.SetActive(true);
    public void CloseSettingUI() => settingPanel.SetActive(false);
}
