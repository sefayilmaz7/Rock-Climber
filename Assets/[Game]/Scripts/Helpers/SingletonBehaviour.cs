using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    { }
}

public abstract class SingletonBehaviour<T> : BaseBehaviour where T : SingletonBehaviour<T>
{
    public static T Instance { get; private set; }

    protected override void Awake()
    {
#if UNITY_EDITOR
        if( !UnityEditor.EditorApplication.isPlaying )
            return;
#endif

        if( Instance == null )
        {
            Instance = (T) this;
            base.Awake();
        }
        else if( this != Instance )
            Destroy( this );
    }
}