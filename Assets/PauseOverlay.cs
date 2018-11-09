using UnityEngine;

public class PauseOverlay : MonoBehaviour
{
    public bool Running
    {
        set { gameObject.SetActive(!value); }
    }
}