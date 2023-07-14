﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

using Bloxstrap.Enums;
using Bloxstrap.Extensions;

using CommunityToolkit.Mvvm.Input;

namespace Bloxstrap.UI.ViewModels.Menu
{
    public class ModsViewModel
    {
        public ICommand OpenModsFolderCommand => new RelayCommand(OpenModsFolder);

        private void OpenModsFolder() => Process.Start("explorer.exe", Directories.Modifications);

        public bool OldDeathSoundEnabled
        {
            get => App.Settings.Prop.UseOldDeathSound;
            set => App.Settings.Prop.UseOldDeathSound = value;
        }

        public bool OldCharacterSoundsEnabled
        {
            get => App.Settings.Prop.UseOldCharacterSounds;
            set => App.Settings.Prop.UseOldCharacterSounds = value;
        }

        public IReadOnlyDictionary<string, Enums.CursorType> CursorTypes => CursorTypeEx.Selections;

        public string SelectedCursorType
        {
            get => CursorTypes.FirstOrDefault(x => x.Value == App.Settings.Prop.CursorType).Key;
            set => App.Settings.Prop.CursorType = CursorTypes[value];
        }

        public bool DisableAppPatchEnabled
        {
            get => App.Settings.Prop.UseDisableAppPatch;
            set => App.Settings.Prop.UseDisableAppPatch = value;
        }

        public IReadOnlyDictionary<string, EmojiType> EmojiTypes => EmojiTypeEx.Selections;

        public string SelectedEmojiType
        {
            get => EmojiTypes.FirstOrDefault(x => x.Value == App.Settings.Prop.EmojiType).Key;
            set => App.Settings.Prop.EmojiType = EmojiTypes[value];
        }

        public bool DisableFullscreenOptimizationsEnabled
        {
            get => App.Settings.Prop.DisableFullscreenOptimizations;
            set => App.Settings.Prop.DisableFullscreenOptimizations = value;
        }
    }
}