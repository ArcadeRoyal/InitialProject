using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AEUtilities
{

    // ********************* USEFUL TRANSFORM FUNTIONS ****************************

    /// <summary>
    /// Converts a Vector3 to Vector3Int
    /// </summary>
    /// <param name="v">Vector3 to convert</param>
    /// <returns>Converted Vector3Int</returns>
    public static Vector3Int PosToInt(Vector3 v)
    {
        return new Vector3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    }

    /// <summary>
    /// Converts a quaternion to it's nearest cardinal
    /// </summary>
    /// <param name="r">The quaternion to convert</param>
    /// <returns>The converted quaternion</returns>
    public static Quaternion RotToCardinal(Quaternion r)
    {
        return Quaternion.Euler(new Vector3(0f, Mathf.Round(r.eulerAngles.y / 90) * 90, 0));
    }

    public static bool CheckGridLinear(Vector3Int v1, Vector3Int v2)
    {
        return (v1.y == v2.y && (v1.x == v2.x || v1.z == v2.z));
    }

    public static Vector3Int GetAdjacentInt(Vector3Int source, Vector3Int target)
    {
        Vector3 normalized = (new Vector3(target.x, target.y, target.z) - new Vector3(source.x, source.y, source.z)).normalized;
        return source + PosToInt(normalized);
    }

    public static bool Adjacent(GameObject o, Vector3Int v1)
    {
        return (v1 == PosToInt(o.transform.position + o.transform.forward) || v1 == PosToInt(o.transform.position + o.transform.forward * -1) ||
            v1 == PosToInt(o.transform.position + o.transform.right) || v1 == PosToInt(o.transform.position + o.transform.right * -1)); 
    }

    // ********************* Tag Checking Functions ****************************

    /// <summary>
    /// Returns a list of all GameTag objects that exist at pos
    /// </summary>
    /// <param name="pos">the position to search</param>
    /// <returns>the list of gametag objects</returns>
    public static List<GameTags> GetTagsAtLocation(Vector3Int pos)
    {
        List<GameTags> taglist = new List<GameTags>();
        Collider[] temp = Physics.OverlapSphere(pos, 0.1f);
        for (int i = 0; i < temp.Length; i++)
            if (temp[i].gameObject.GetComponent<GameTags>() != null)
                taglist.Add(temp[i].gameObject.GetComponent<GameTags>());
        return taglist;
    }

    /// <summary>
    /// Returns true if tag exists at location
    /// </summary>
    /// <param name="pos">location to check</param>
    /// <param name="tag">tag to check</param>
    /// <returns>true if tag exists at location</returns>
    public static bool CheckTagAtLocation(Vector3Int pos, string tag)
    {
        List<GameTags> taglist = GetTagsAtLocation(pos);
        for (int i = 0; i < taglist.Count; i++)
            if (taglist[i].CheckTag(tag))
                return true;
        return false;
    }

    /// <summary>
    /// Returns true if tag exists at location, and sets o to the game object of the tag
    /// </summary>
    /// <param name="pos">location to check</param>
    /// <param name="tag">tag to check</param>
    /// <param name="o">output game object</param>
    /// <returns>true if tag exists at location</returns>
    public static bool CheckTagAtLocation(Vector3Int pos, string tag, out GameObject o)
    {
        List<GameTags> taglist = GetTagsAtLocation(pos);
        for (int i = 0; i < taglist.Count; i++)
            if (taglist[i].CheckTag(tag))
            {
                o = taglist[i].gameObject;
                return true;
            }
        o = null;
        return false;
    }

    /// <summary>
    /// Returns true if tag exists at location
    /// </summary>
    /// <param name="pos">location to check</param>
    /// <param name="tag">tag to check</param>
    /// <returns>true if tag exists at location</returns>
    public static bool CheckTagsAtLocation(Vector3Int pos, string[] tags)
    {
        List<GameTags> taglist = GetTagsAtLocation(pos);
        for (int i = 0; i < taglist.Count; i++)
            for (int j = 0; j < tags.Length; j++ )
                if (taglist[i].CheckTag(tags[j]))
                    return true;
        return false;
    }

    /// <summary>
    /// Returns true if tag exists at location, and sets o to the game object of the tag
    /// </summary>
    /// <param name="pos">location to check</param>
    /// <param name="tag">tag to check</param>
    /// <param name="o">output game object</param>
    /// <returns>true if tag exists at location</returns>
    public static bool CheckTagsAtLocation(Vector3Int pos, string[] tags, out GameObject o)
    {
        List<GameTags> taglist = GetTagsAtLocation(pos);
        for (int i = 0; i < taglist.Count; i++)
            for (int j = 0; j < tags.Length; j++)
                if (taglist[i].CheckTag(tags[j]))
                {
                    o = taglist[i].gameObject;
                    return true;
                }
        o = null;
        return false;
    }

}
