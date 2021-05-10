using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToolBase : MonoBehaviour
{
    [SerializeField]
    public Vector3 position; //location of object before hiding it
    public Quaternion rotation; //rotation
    [SerializeField]
    public GameObject OBJ_prefab; // Gameobject of this tool
    [SerializeField]
    public Texture2D[] MousePointers = new Texture2D[2]; //sprite of animations

    public string toolName;

    //some interactions shit
    public void SendDataToToolController()
    {
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().position = new Vector3(this.position.x, this.position.y, this.position.z);
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().rotation = new Quaternion(this.rotation.x, this.rotation.y, this.rotation.z, this.rotation.w);
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().OBJ_prefab = Instantiate(this.OBJ_prefab, new Vector3(-30, 0, 0), Quaternion.identity);
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().MousePointers[0] = this.MousePointers[0];
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().MousePointers[1] = this.MousePointers[1];
        PLAYERCONTROLLER.try3.Instance.transform.GetComponent<ToolController>().ActiveTool = toolName;

    }

}
