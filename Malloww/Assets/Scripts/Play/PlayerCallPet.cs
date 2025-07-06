using UnityEngine;
using System.Collections.Generic;

public class PlayerCallPet : MonoBehaviour
{
    public GameObject petPrefab;
    public Transform playerTransform;

    public float baseDistance = 1.5f;
    public float spacing = 1.2f;

    private List<PetController> petList = new List<PetController>();

    public void SummonPet()
    {
        if (petPrefab == null || playerTransform == null)
        {
            Debug.LogWarning("⚠ Pet Prefab hoặc Player Transform chưa gán.");
            return;
        }

        Vector3 spawnPos = playerTransform.position + Vector3.right * (baseDistance + spacing * petList.Count);
        GameObject pet = Instantiate(petPrefab, spawnPos, Quaternion.identity);

        PetController petController = pet.GetComponent<PetController>();
        if (petController != null)
        {
            petController.player = playerTransform;
            petController.SetManager(this);  // Gán manager để pet báo ngược về
            petList.Add(petController);
            UpdatePetPositions();
        }

        Debug.Log($"🐾 Đã spawn pet thứ {petList.Count}");
    }

    // Khi pet chết → gọi hàm này để remove
    public void RemovePet(PetController pet)
    {
        if (petList.Contains(pet))
        {
            petList.Remove(pet);
            UpdatePetPositions();
        }
    }

    // Cập nhật lại vị trí follow của từng pet
    private void UpdatePetPositions()
    {
        for (int i = 0; i < petList.Count; i++)
        {
            petList[i].followOffsetX = baseDistance + spacing * i;
        }
    }
}
