using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.InputManagerEntry;

public class SkinPreviewManager : MonoBehaviour
{
    public Image previewImage;  // Gắn ảnh preview ở giữa
    public Sprite defaultSkin;
    public Sprite skinA;
    public Sprite skinB;
    public Sprite skinC;

    public void ShowPreviewInt(int skinId)
    {
        SkinType skin = (SkinType)skinId;

        // Kiểm tra nếu skin đã unlock thì mới cho preview
        if (!IsSkinUnlocked(skin))
        {
            Debug.LogWarning($"⚠ Skin {skin} chưa mua → không cho preview!");
            return;
        }

        ShowPreviewInternal(skin);
    }

    private void ShowPreviewInternal(SkinType skin)
    {
        switch (skin)
        {
            case SkinType.Default:
                previewImage.sprite = defaultSkin;
                break;
            case SkinType.SkinA:
                previewImage.sprite = skinA;
                break;
            case SkinType.SkinB:
                previewImage.sprite = skinB;
                break;
            case SkinType.SkinC:
                previewImage.sprite = skinC;
                break;
        }

        Debug.Log($"🔍 Đã preview skin: {skin}");
    }

    private bool IsSkinUnlocked(SkinType skin)
    {
        return PlayerPrefs.GetInt("Skin_" + skin.ToString(), 0) == 1;
    }

}
