//using UnityEngine;

//public class ControladorSonido : MonoBehaviour
//{
//    public static ControladorSonido instance;

//    private AudioSource audioSource;

//    private void Awake()
//    {
//        if(instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//        audioSource = GetComponent<AudioSource>();
//    }

//    public void EjecutarSonido(audioClip sonido)
//    {
//        audioSource.PlayOneShot(sonido);
//    }
//}
