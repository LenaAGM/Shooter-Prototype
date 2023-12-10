using UnityEngine;

public class State<T> : MonoBehaviour where T : Controller
{
    public T Controller;
}