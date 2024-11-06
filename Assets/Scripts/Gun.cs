using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet; // Prefab da bala a ser disparada
    public bool canAutoFire; // Define se a arma pode disparar automaticamente
    public float fireRate; // Taxa de disparo
    [HideInInspector]
    public float fireCounter; // Contador para controlar o tempo entre disparos
    public int currentAmmunition; // Quantidade atual de muni��o na arma

    void Update()
    {
        // Este script � uma base para a l�gica de disparo e pode ser expandido conforme necess�rio
    }
}
