﻿using System.IO;
using System.Reflection;
using UnityEngine;
using ModSettings;

namespace StickPick
{
    internal class StickPickSettingsMain : JsonModSettings
    {    
        [Section("Keybind")]

		[Name("Pick up")]
		[Description("Pick up items in radius around you")]
		public UnityEngine.KeyCode buttonPickSticks = KeyCode.LeftAlt;

		[Section("Skip Item Inspection Menu")]

		[Name("Skip Item Inspection")]
		[Description("Choose which items(if any) to skip inspection menu on.")]
		[Choice("None", "All", "Sticks and stones")]
		public int SkipInspectChoice = 0;

		[Section("Stickpick")]

		[Name("What to pick")]
		[Description("Choose between stick, stones or sticks & stones")]
		[Choice("Sticks", "Stones", "Sticks and stones")]
		public int pickupChoice = 0;

		[Name("Pickup radius")]
		[Description("Choose the radius (sphere) around the player which gets searched for objects")]
		[Slider(0f, 15f)]
		public float pickupRadius = 2.0f;

		[Name("Pickup calorie cost")]
		[Description("Calorie penalty for picking up a single stick/stone (multiplied if more than one items gets picked up)")]
		[Slider(0, 25)]
		public int calorieCost = 5;

		[Name("Enable custom item list")]
		[Description("Picks up any (valid) item listed in the StickPickCustomList.txt")]
		public bool pickUpAdditionalItems = false;

		protected override void OnConfirm()
        {
            base.OnConfirm();
			StickPick_Main.loadCustomItemList();
		}
    }

    internal static class Settings
    {
        public static StickPickSettingsMain options;

        public static void OnLoad()
        {
            options = new StickPickSettingsMain();
            options.AddToModSettings("StickPick Settings");
			StickPick_Main.loadCustomItemList();
		}
    }
}
