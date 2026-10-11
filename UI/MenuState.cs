using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace SpawnRateScaler.UI
{
    public class MyMenuState : UIState
	{
        public DraggableUIPanel panel;
        public CustomSlider slider;
        public UITextPanel<string> lockButton;
        public UIText currentRate;

        private bool locked = false;

        public override void OnInitialize()
        {
			panel = new();

            // main panel
			panel.Width.Set(300f, 0f);
			panel.Height.Set(200f, 0f);

			panel.Left.Set(400f, 0f);
			panel.Top.Set(400f, 0f);

            // header text
			UIText titleText = new("Test Menu");
			titleText.Top.Set(10f, 0f);
			titleText.HAlign = 0.5f;
			panel.Append(titleText);

            // slider
            slider = new(200f, 50f)
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            panel.Append(slider);

            // current rate text
            currentRate = new("---")
            {
                HAlign = 0.5f,
                VAlign = 0.35f
            };
            panel.Append(currentRate);

            // lock button
            lockButton = new("Lock", 0.60f, false);
            lockButton.Width.Set(20f, 0f);
            lockButton.Height.Set(20f, 0f);

            lockButton.HAlign = 0.95f;
            lockButton.VAlign = 0.025f;

            lockButton.OnLeftClick += ToggleLockPanel;

            panel.Append(lockButton);

            // ------
			Append(panel);

            ToggleLockPanel(null, null);
        }

        public float GetSliderValue()
        {
            currentRate.SetText($"Multiplier: {slider.Value * 10:F1}");
            return slider.Value;
        }

        private void ToggleLockPanel(UIMouseEvent evt, UIElement listeningElement)
        {
            locked = !locked;

            // if the panel is locked and cant move, the slider is active
            // if the panel can move, the slider should be deactivated
            panel.isLocked = locked;
            slider.isLocked = !locked;

            lockButton.SetText(locked ? "Unlock" : "Lock");

            Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.MenuTick);
        }
    }
}