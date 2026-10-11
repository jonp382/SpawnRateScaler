using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

using SpawnRateScaler.UI;

namespace SpawnRateScaler
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class SpawnRateScaler : ModSystem
	{
		private UserInterface myUserInterface;
		private MyMenuState myMenuState;
		public override void PostSetupContent()
		{
			if (!Main.dedServ)
			{
				myUserInterface = new UserInterface();
				myMenuState = new MyMenuState();
				myMenuState.Activate();

				myUserInterface.SetState(myMenuState);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if(Main.playerInventory){
				if(myUserInterface?.CurrentState == null) myUserInterface.SetState(myMenuState);
				myUserInterface.Update(gameTime);
			}
			else
			{
				myUserInterface.SetState(null);
			}
		}

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
   	 	{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MyMod: My Custom Menu",
					delegate {
						if (myUserInterface?.CurrentState != null)
						{
							myUserInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
					},
					InterfaceScaleType.UI));
			}
		}
	}

	

	
}