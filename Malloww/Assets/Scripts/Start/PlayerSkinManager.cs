using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;  // Gắn SpriteRenderer của Player
    public Sprite defaultSkin;
    public Sprite skinA;
    public Sprite skinB;
    public Sprite skinC;

    private SkinType currentSkin = SkinType.Default;

    void Start()
    {
        // Tìm spriteRenderer như cũ
        if (playerSpriteRenderer == null)
            playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        LoadSkin();
        ApplySkin(currentSkin);
    }

    public void UnlockSkin(SkinType skin)
    {
        // Lưu skin đã mở vào PlayerPrefs
        PlayerPrefs.SetInt("Skin_" + skin.ToString(), 1);
        PlayerPrefs.Save();

        Debug.Log($"🎨 Đã unlock skin: {skin}");
    }

    public void ApplySkin(SkinType skin)
    {
        currentSkin = skin;

        switch (skin)
        {
            case SkinType.Default:
                playerSpriteRenderer.sprite = defaultSkin;
                break;
            case SkinType.SkinA:
                playerSpriteRenderer.sprite = skinA;
                break;
            case SkinType.SkinB:
                playerSpriteRenderer.sprite = skinB;
                break;
            case SkinType.SkinC:
                playerSpriteRenderer.sprite = skinC;
                break;
        }

        PlayerPrefs.SetString("CurrentSkin", skin.ToString());
        PlayerPrefs.Save();

        Debug.Log($"✅ Đã áp dụng skin: {skin}");
    }

    public void LoadSkin()
    {
        string savedSkin = PlayerPrefs.GetString("CurrentSkin", "Default");
        if (System.Enum.TryParse(savedSkin, out SkinType loadedSkin) && IsSkinUnlocked(loadedSkin))
        {
            currentSkin = loadedSkin;
        }
        else
        {
            currentSkin = SkinType.Default;
        }
    }

    public bool IsSkinUnlocked(SkinType skin)
    {
        return PlayerPrefs.GetInt("Skin_" + skin.ToString(), 0) == 1;
    }
}
