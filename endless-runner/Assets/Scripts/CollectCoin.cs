using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFx;

    void OnTriggerEnter(Collider other)
    {
        coinFx.Play();
        this.gameObject.SetActive(false);
    }

}
