using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public int itemIDnecessario;
    public bool preenchido = false;

    void OnTriggerEnter(Collider other)
    {
        if (preenchido) return;

        if (other.CompareTag("Player"))
        {
            if (InventarioFaseSombra.Instance.TemItem(itemIDnecessario))
            {
                Transform children = transform.GetChild(0);
                children.gameObject.SetActive(true);

                InventarioFaseSombra.Instance.RemoveItem(itemIDnecessario);

                preenchido = true;

                PedestalManager.Instance.CheckPedestals();

            }
            else
            {

            }
        }
    }

}
