using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    [Serializable]
    public class LevelEditorResource : ILevelEditorResource, IEditorTreeViewItem<LevelEditorResource>, IEquatable<LevelEditorResource>
    {
        [SerializeField]
        private string name = "New Resource";
        [SerializeField]
        private string id = "new_resource";
        [SerializeField]
        private bool customIcon = false;
        [SerializeField]
        private Sprite icon = null;
        [SerializeField]
        private int limit = 0;
        [SerializeField]
        private bool hidden = false;
        [SerializeField]
        private UnityEngine.Object asset = null;

        [SerializeField]
        private int treeID = 0;
        [SerializeField]
        private int treeDepth = 0;
        [NonSerialized]
        private LevelEditorResource parent;
        [NonSerialized]
        private List<LevelEditorResource> children;

        public string Name { get { return name; } set { name = value; } }
        public string ID { get { return id; } set { id = value; } }
        public int Limit { get { return limit; } set { limit = value; } }
        public bool Hidden { get { return hidden; } set { hidden = value; } }
        public bool CustomIcon { get { return customIcon; } set { customIcon = value; } }
        public Sprite Icon { get { return icon; } set { icon = value; } }
        public UnityEngine.Object Asset { get { return asset; } set { asset = value; } }

        public int TreeID { get { return treeID; } set { treeID = value; } }
        public int TreeDepth { get { return treeDepth; } set { treeDepth = value; } }
        public LevelEditorResource Parent { get { return parent; } set { parent = value; } }
        public List<LevelEditorResource> Children { get { return children; } set { children = value; } }

        public LevelEditorResource() { }

        public LevelEditorResource(LevelEditorResource copy)
        {
            name = copy.name;
            id = copy.id;
            customIcon = copy.customIcon;
            icon = copy.icon;
            limit = copy.limit;
            hidden = copy.hidden;
            asset = copy.asset;
            treeID = copy.treeID;
            treeDepth = copy.treeDepth;
            parent = copy.parent;
            children = copy.children;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LevelEditorResource);
        }

        public bool Equals(LevelEditorResource other)
        {
            return other != null && customIcon == other.customIcon && hidden == other.hidden && limit == other.limit &&
                   treeID == other.treeID && treeDepth == other.treeDepth && id == other.id;
        }

        public override int GetHashCode()
        {
            int hashCode = 29301770;
            hashCode = hashCode * -1521134295 + customIcon.GetHashCode();
            hashCode = hashCode * -1521134295 + hidden.GetHashCode();
            hashCode = hashCode * -1521134295 + limit.GetHashCode();
            hashCode = hashCode * -1521134295 + treeID.GetHashCode();
            hashCode = hashCode * -1521134295 + treeDepth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            return hashCode;
        }

        public static bool operator ==(LevelEditorResource left, LevelEditorResource right)
        {
            return EqualityComparer<LevelEditorResource>.Default.Equals(left, right);
        }

        public static bool operator !=(LevelEditorResource left, LevelEditorResource right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"LevelEditorResource (Name: {name}, ID: {id}, Hidden: {hidden}, Limit: {limit})";
        }
    }
}
