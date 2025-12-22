using UnityEngine;

public class desactivar_cosas : MonoBehaviour
{
    public GameObject[] textos;
    public GameObject primer_texto;
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
