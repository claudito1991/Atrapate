using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaterial : MonoBehaviour
{
    [SerializeField] Material bulltetMaterial;

    private void OnEnable()
    {
        bulltetMaterial.color = Color.green;
    }
}
