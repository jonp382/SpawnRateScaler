using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace SpawnRateScaler.UI
{
    public class CustomSlider : UIElement
    {
        private float _value = 0f; // bounde between 0.0 and 1.0
        public float Value { get => _value; set => _value = MathHelper.Clamp(value, 0f, 1f); }
        private bool dragging = false;
        public bool isLocked = false;

        public CustomSlider(float width, float height)
        {
            Width.Set(width, 0f);
            Height.Set(height, 0f);
            Value = 0.1f; // *10 so this is 1.0
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            base.LeftMouseDown(evt);
            dragging = true;
        }

        public override void LeftMouseUp(UIMouseEvent evt)
        {
            base.LeftMouseUp(evt);
            dragging = false;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (dragging)
            {
                UpdateSliderValue();
            }
        }

        private void UpdateSliderValue()
        {
            if(isLocked) return;
            
            CalculatedStyle dimensions = GetInnerDimensions();
            float mouseX = Main.mouseX;
            float relativeX = mouseX - dimensions.X;
            Value = relativeX / dimensions.Width;
        }

        public void OverrideSliderValue(float newValue) => Value = newValue;

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetInnerDimensions();
            
            Texture2D tex = TextureAssets.MagicPixel.Value; // generic pixel that is colored per item

            // background rail
            Rectangle backgroundRect = new Rectangle((int)dimensions.X, (int)(dimensions.Y + dimensions.Height / 2 - 2), (int)dimensions.Width, 4);
            spriteBatch.Draw(tex, backgroundRect, Color.DarkGray);

            // draggable thing
            float dragX = dimensions.X + (dimensions.Width * Value) - 6f;
            float dragY = dimensions.Y + (dimensions.Height / 2) - 10f;
            Rectangle dragRect = new Rectangle((int)dragX, (int)dragY, 12, 20);            
            Color dragColor = IsMouseHovering || dragging ? Color.White : Color.LightGray;  // colored white if hovered over
            spriteBatch.Draw(tex, dragRect, dragColor);
        }
    }
}