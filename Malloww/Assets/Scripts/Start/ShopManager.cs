using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerSkinManager playerSkinManager;

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
        if (CoinManager.instance.SpendCoin(cost))
        {
            // Chỉ lưu thông tin skin, không apply ngay
            PlayerPrefs.SetInt("Skin_" + skinType.ToString(), 1);  // Đánh dấu đã unlock
            PlayerPrefs.SetString("CurrentSkin", skinType.ToString()); // Lưu skin đang chọn
            PlayerPrefs.Save();

            Debug.Log($"✅ Đã mua và lưu skin {skinType}");
        }
        else
        {
            Debug.Log("❌ Không đủ coin để mua skin!");
        }
    }




    // Nếu sau này thêm Pet, Skill, Boost... chỉ cần thêm hàm kiểu này:
    //public void BuyPet(string petName, int cost) { ... }
}
