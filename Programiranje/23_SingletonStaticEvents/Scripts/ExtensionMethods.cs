using UnityEngine;

public static class ExtensionMethods
{
    public static void ActivateChildren(this Transform transform)
    {
        var children = transform.GetComponentsInChildren<Transform>(true);
        for (int i = 1; i < children.Length; i++)
        {
            children[i].gameObject.SetActive(true);
        }
    }

    public static void SetChildrenActive(this Transform transform, bool newActive)
    {
        var children = transform.GetComponentsInChildren<Transform>(true);
        for (int i = 1; i < children.Length; i++)
        {
            children[i].gameObject.SetActive(newActive);
        }
    }

    public static void Activate(this GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void Deactivate(this GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static void ResetTransform(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
