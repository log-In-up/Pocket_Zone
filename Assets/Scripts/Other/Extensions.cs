using UnityEngine;

public static class Extensions
{
    public static void GetSafeComponent<T>(this GameObject gameObject, out T component) where T : Component
    {
        if (gameObject.TryGetComponent(out T foundComponent))
        {
            component = foundComponent;
        }
        else
            throw new System.Exception($"There is no {typeof(T)} component on the {gameObject}.");
    }
}
