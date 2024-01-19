using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public static class Managers
{
    public static ObjectPoolManager ObjPool => ObjectPoolManager.Instance;
    public static SoundManager SoundManager => SoundManager.Instance;
}

