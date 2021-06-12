using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersionManager.Models
{
    public class SoftwareVersion : IComparable<SoftwareVersion>
    {

        private static int MAJOR_VERSION_INDEX = 0;
        private static int MINOR_VERSION_INDEX = 1;
        private static int PATCH_VERSION_INDEX = 2;

        public int MajorVersion { get; private set; }

        public int MinorVersion { get; private set; }

        public int PatchVersion { get; private set; }

        public SoftwareVersion(string unparsedVersion)
        {
            if (string.IsNullOrEmpty(unparsedVersion))
                throw new ArgumentException("Invalid version format.  Please provide versions in the format [major].[minor].[path].");

            var versionComponents =  unparsedVersion.Split('.');

            this.MajorVersion = ParseVersionComponent(versionComponents, MAJOR_VERSION_INDEX);

            if (versionComponents.Length > MINOR_VERSION_INDEX)
                this.MinorVersion = ParseVersionComponent(versionComponents, MINOR_VERSION_INDEX);

            if (versionComponents.Length > PATCH_VERSION_INDEX)
                this.PatchVersion = ParseVersionComponent(versionComponents, PATCH_VERSION_INDEX);

        }

        public SoftwareVersion(int major, int minor, int patch)
        {
            this.MajorVersion = major;
            this.MinorVersion = minor;
            this.PatchVersion = patch;
        }

        private int ParseVersionComponent(string[] versionComponents, int index)
        {
            var versionNum = 0;

            // if there was a trailing period in the string, default the component to 0
            if (string.IsNullOrEmpty(versionComponents[index]))
                return 0;

            if (!Int32.TryParse(versionComponents[index], out versionNum))
                throw new ArgumentException("All version components must be integers");

            return versionNum;
        }

        public int CompareTo(SoftwareVersion other)
        {
            var majorVersionComparison = this.MajorVersion.CompareTo(other.MajorVersion);

            if (majorVersionComparison != 0)
                return majorVersionComparison;

            var minorVersionComparison = this.MinorVersion.CompareTo(other.MinorVersion);

            if (minorVersionComparison!= 0)
                return minorVersionComparison;

            var patchVersionComparison = this.PatchVersion.CompareTo(other.PatchVersion);

            if (patchVersionComparison != 0)
                return patchVersionComparison;

            return 0;

        }

        public bool IsGreaterThan(SoftwareVersion other)
        {
            return this.CompareTo(other) > 0;
        }
    }
}
