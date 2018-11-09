using UnityEngine;

public class PauseOverlay : MonoBehaviour
{
    public bool Paused
    {
        set { gameObject.SetActive(value); }
    }
}