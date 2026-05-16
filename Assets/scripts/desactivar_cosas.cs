using UnityEngine;

public class desactivar_cosas : MonoBehaviour
{
    public GameObject[] textos;
    public GameObject primer_texto;
    public GameObject ultimo_texto;
    public GameObject boton_siguiente;
    public GameObject boton_iniciar;
    private int cantidad_textos;
    private int contador = 0;

    void Awake()
    {
        cantidad_textos = textos.Length;
    }

    public void Aparecer()
    {
        if (primer_texto.activeSelf)
        {
            primer_texto.SetActive(false);
        }

        if (contador < cantidad_textos)
        {
            if (textos[contador].activeSelf)
            {
                textos[contador].SetActive(false);
                contador += 1;
                Debug.Log("Contador: "+ contador);
                Debug.Log("Cantidad texto: "+ cantidad_textos);
            }
            else
            {
                textos[contador].SetActive(true);

                if (ultimo_texto.activeSelf)
                {
                    boton_siguiente.SetActive(false);
                    boton_iniciar.SetActive(true);
                }

                if (contador > 0)
                {
                    textos[contador-1].SetActive(false);
                }

                contador += 1;
                Debug.Log("Contador: "+ contador);
                Debug.Log("Cantidad texto: "+ cantidad_textos);
            }
        }
    }

    public void Volver()
    {
        if (contador > 0)
        {
            if (ultimo_texto.activeSelf)
            {
                boton_siguiente.SetActive(true);
                boton_iniciar.SetActive(false);
            }

            if (textos[contador-1].activeSelf)
            {
                textos[contador-1].SetActive(false);

                if (contador-1 != 0)
                {
                    textos[contador-2].SetActive(true);
                }
                else
                {
                    if (primer_texto.activeSelf == false)
                    {
                        primer_texto.SetActive(true);
                    }
                }

                contador -= 1;

                Debug.Log("Contador: "+ contador);
                Debug.Log("Cantidad texto: "+ cantidad_textos);
            }
            else
            {
                textos[contador-1].SetActive(true);

                contador -= 1;
                if (contador == 0)
                {
                    if (primer_texto.activeSelf == false)
                    {
                        primer_texto.SetActive(true);
                    }
                }
                Debug.Log("Contador: "+ contador);
                Debug.Log("Cantidad texto: "+ cantidad_textos);
            }
        }
    }
}
