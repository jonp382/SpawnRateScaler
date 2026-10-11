using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace SpawnRateScaler.UI
{
    public class MyMenuState : UIState
	{
        public override void OnInitialize()
        {
			DraggableUIPanel panel = new();

			panel.Width.Set(300f, 0f);
			panel.Height.Set(200f, 0f);

			panel.Left.Set(400f, 0f);
			panel.Top.Set(400f, 0f);

			UIText titleText = new("Test Menu");
			titleText.Top.Set(10f, 0f);
			titleText.HAlign = 0.5f;
			panel.Append(titleText);

			Append(panel);
        }
	}
}