using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    [Serializable]
    public struct PlayModeRequirement : IEquatable<PlayModeRequirement>
    {
        public LevelEditorIdentifier objectID;
        public int minAmount;
        public bool mustBeActive;

        public override bool Equals(object obj)
        {
            return obj is PlayModeRequirement requirements && Equals(requirements);
        }

        public bool Equals(PlayModeRequirement other)
        {
            return mustBeActive == other.mustBeActive && minAmount == other.minAmount && objectID == other.objectID;
        }

        public override int GetHashCode()
        {
            int hashCode = 793019971;
            hashCode = hashCode * -1521134295 + objectID.GetHashCode();
            hashCode = hashCode * -1521134295 + minAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + mustBeActive.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PlayModeRequirement left, PlayModeRequirement right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayModeRequirement left, PlayModeRequirement right)
        {
            return !(left == right);
        }
    }
}
