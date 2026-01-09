using UnityEngine;

public class InventarioUIL : MonoBehaviour
{
    public GameObject[] itemIcons;

    public void ShowItem(int id)
    {
        if (id < 0 || id >= itemIcons.Length)
        {
            return;
        }

        itemIcons[id].SetActive(true);

    }
}
