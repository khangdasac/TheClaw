using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableTransform
{
    public SerializableVector3 position;
    public SerializableQuaternion rotation;
    public SerializableVector3 scale;

    public SerializableTransform(SerializableVector3 position, SerializableQuaternion rotation, SerializableVector3 scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }

    public SerializableTransform(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        this.position = new SerializableVector3(position);
        this.rotation = new SerializableQuaternion(rotation);
        this.scale = new SerializableVector3(scale);
    }

    public SerializableTransform(Transform transform)
    {
        this.position = new SerializableVector3(transform.localPosition);
        this.rotation = new SerializableQuaternion(transform.localRotation);
        this.scale = new SerializableVector3(transform.localScale);
    }

    public void ApplyToTransform(Transform transform)
    {
        transform.position = this.position.ToVector3();
        transform.rotation = this.rotation.ToQuaternion(); 
        transform.localScale = this.scale.ToVector3();
    }

    public void ApplyToLocalTransform(Transform transform)
    {
        transform.localPosition = this.position.ToVector3();
        transform.localRotation = this.rotation.ToQuaternion();
        transform.localScale = this.scale.ToVector3();
    }
}
