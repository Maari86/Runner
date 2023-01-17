using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHolder : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private void Update()
    {
        transform.localScale = Player.localScale;
    }
}
