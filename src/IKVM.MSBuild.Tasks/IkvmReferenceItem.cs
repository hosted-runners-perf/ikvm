﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Build.Framework;

namespace IKVM.MSBuild.Tasks
{

    /// <summary>
    /// Models the required data of a <see cref="IkvmReferenceItem"/>.
    /// </summary>
    class IkvmReferenceItem
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IkvmReferenceItem(ITaskItem item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        /// <summary>
        /// Referenced node.
        /// </summary>
        public ITaskItem Item { get; }

        /// <summary>
        /// Unique name of the item.
        /// </summary>
        public string ItemSpec { get; set; }

        /// <summary>
        /// Assembly name.
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Assembly version.
        /// </summary>
        public string AssemblyVersion { get; set; }

        /// <summary>
        /// Assembly file version. If not specified, defaults to the assembly version.
        /// </summary>
        public string AssemblyFileVersion { get; set; }

        /// <summary>
        /// Disable automatic detection of the assembly name.
        /// </summary>
        public bool DisableAutoAssemblyName { get; set; } = false;

        /// <summary>
        /// Disable automatic detection of the assembly version.
        /// </summary>
        public bool DisableAutoAssemblyVersion { get; set; } = false;

        /// <summary>
        /// Assembly name to use if no other assembly name is available.
        /// </summary>
        public string FallbackAssemblyName { get; set; }

        /// <summary>
        /// Assembly version to use if no other assembly version is available.
        /// </summary>
        public string FallbackAssemblyVersion { get; set; }

        /// <summary>
        /// Set of sources to compile.
        /// </summary>
        public List<string> Compile { get; set; } = new List<string>();

        /// <summary>
        /// Set of Java sources which can be used to generate documentation.
        /// </summary>
        public List<string> Sources { get; set; } = new List<string>();

        /// <summary>
        /// References required to compile.
        /// </summary>
        public List<IkvmReferenceItem> References { get; set; } = new List<IkvmReferenceItem>();

        /// <summary>
        /// Name of the classloader to use.
        /// </summary>
        public string ClassLoader { get; set; }

        /// <summary>
        /// Unique IKVM identity of the reference.
        /// </summary>
        public string IkvmIdentity { get; set; }

        /// <summary>
        /// Path in cache where resulting item will be stored.
        /// </summary>
        public string CachePath { get; set; }

        /// <summary>
        /// path in cache where the resulting symbols will be stored.
        /// </summary>
        public string CacheSymbolsPath { get; set; }

        /// <summary>
        /// Path to temporarily generated item.
        /// </summary>
        public string StagePath { get; set; }

        /// <summary>
        /// Path to the temporarily generated symbols file.
        /// </summary>
        public string StageSymbolsPath { get; set; }

        /// <summary>
        /// Aliases to make the assembly available under.
        /// </summary>
        public string Aliases { get; set; }

        /// <summary>
        /// Compile in debug mode.
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// Path to the file to sign the assembly.
        /// </summary>
        public string KeyFile { get; set; }

        /// <summary>
        /// Whether to delay sign the produced assembly.
        /// </summary>
        public bool DelaySign { get; set; }

        /// <summary>
        /// Whether the itme will be copied along with the build output.
        /// </summary>
        public bool Private { get; set; } = true;

        /// <summary>
        /// Whether a reference should be added to this item.
        /// </summary>
        public bool ReferenceOutputAssembly { get; set; } = true;

        /// <summary>
        /// Paths to other referenced items.
        /// </summary>
        public List<string> ResolvedReferences { get; set; }

        /// <summary>
        /// Writes the metadata to the item.
        /// </summary>
        public void Save()
        {
            Item.ItemSpec = ItemSpec;
            Item.SetMetadata(IkvmReferenceItemMetadata.AssemblyName, AssemblyName);
            Item.SetMetadata(IkvmReferenceItemMetadata.AssemblyVersion, AssemblyVersion);
            Item.SetMetadata(IkvmReferenceItemMetadata.AssemblyFileVersion, AssemblyFileVersion);
            Item.SetMetadata(IkvmReferenceItemMetadata.DisableAutoAssemblyName, DisableAutoAssemblyName ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.DisableAutoAssemblyVersion, DisableAutoAssemblyVersion ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.FallbackAssemblyName, FallbackAssemblyName);
            Item.SetMetadata(IkvmReferenceItemMetadata.FallbackAssemblyVersion, FallbackAssemblyVersion);
            Item.SetMetadata(IkvmReferenceItemMetadata.Compile, string.Join(IkvmReferenceItemMetadata.PropertySeperatorString, Compile));
            Item.SetMetadata(IkvmReferenceItemMetadata.Sources, string.Join(IkvmReferenceItemMetadata.PropertySeperatorString, Sources));
            Item.SetMetadata(IkvmReferenceItemMetadata.References, string.Join(IkvmReferenceItemMetadata.PropertySeperatorString, References.Select(i => i.ItemSpec)));
            Item.SetMetadata(IkvmReferenceItemMetadata.ClassLoader, ClassLoader);
            Item.SetMetadata(IkvmReferenceItemMetadata.IkvmIdentity, IkvmIdentity);
            Item.SetMetadata(IkvmReferenceItemMetadata.CachePath, CachePath);
            Item.SetMetadata(IkvmReferenceItemMetadata.CacheSymbolsPath, CacheSymbolsPath);
            Item.SetMetadata(IkvmReferenceItemMetadata.StagePath, StagePath);
            Item.SetMetadata(IkvmReferenceItemMetadata.StageSymbolsPath, StageSymbolsPath);
            Item.SetMetadata(IkvmReferenceItemMetadata.Aliases, Aliases);
            Item.SetMetadata(IkvmReferenceItemMetadata.Debug, Debug ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.KeyFile, KeyFile);
            Item.SetMetadata(IkvmReferenceItemMetadata.DelaySign, DelaySign ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.Private, Private ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.ReferenceOutputAssembly, ReferenceOutputAssembly ? "true" : "false");
            Item.SetMetadata(IkvmReferenceItemMetadata.ResolvedReferences, string.Join(IkvmReferenceItemMetadata.PropertySeperatorString, ResolvedReferences));
        }

    }

}
