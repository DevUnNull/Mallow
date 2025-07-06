using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerSkinManager playerSkinManager;
    public void BuySkinDefault()
    {
        BuySkin(SkinType.Default, 0);
    }
    public void BuySkinA()
    {
        BuySkin(SkinType.SkinA, 100);
    }

    public void BuySkinB()
    {
        BuySkin(SkinType.SkinB, 200);
    }
    public void BuySkinC()
    {
        BuySkin(SkinType.SkinC, 300);
    }
    public void BuySkin(SkinType skinType, int cost)
    {
        // Kiểm tra trực tiếp PlayerPrefs
        if (PlayerPrefs.GetInt("Skin_" + skinType.ToString(), 0) == 1)
        {
            Debug.Log($"⚠ Skin {skinType} đã mua trước đó → không mua lại.");
            PlayerPrefs.SetString("CurrentSkin", skinType.ToString());
            PlayerPrefs.Save();
            return;
        }

        // Chưa mua thì trừ coin và unlock
        if (CoinManager.instance.SpendCoin(cost))
        {
            PlayerPrefs.SetInt("Skin_" + skinType.ToString(), 1);  // Unlock
            PlayerPrefs.SetString("CurrentSkin", skinType.ToString());
            PlayerPrefs.Save();

            Debug.Log($"✅ Mua thành công skin: {skinType}");
        }
        else
        {
            Debug.Log("❌ Không đủ coin để mua skin!");
        }
    }




    // Nếu sau này thêm Pet, Skill, Boost... chỉ cần thêm hàm kiểu này:
    //public void BuyPet(string petName, int cost) { ... }
}
