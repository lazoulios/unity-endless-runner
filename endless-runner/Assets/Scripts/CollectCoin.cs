using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFx;
    public GameManager manager;
    int count =0;

    void OnTriggerEnter(Collider other)
    {
        coinFx.Play();
        this.gameObject.SetActive(false);
        if (count ==0)
        {
            count = 1;
            manager.UpdateScore();
        }
    }

}
