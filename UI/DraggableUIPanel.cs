using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace SpawnRateScaler.UI
{
    public class DraggableUIPanel : UIPanel
    {
        private bool isDragging = false;
        public bool isLocked = false;
        private Vector2 offset;

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            base.LeftMouseDown(evt);
            isDragging = true;
            offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
        }

        public override void LeftMouseUp(UIMouseEvent evt)
        {
            base.LeftMouseUp(evt);
            isDragging = false;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            if(isLocked) return;

            if (isDragging)
            {
                Left.Set(
                    Math.Clamp(
                        Main.mouseX - offset.X, 
                        0f, 
                        Main.screenWidth - Width.Pixels), 
                    0f);

                Top.Set(
                    Math.Clamp(
                        Main.mouseY - offset.Y, 
                        0f,
                        Main.screenHeight - Height.Pixels),
                    0f);

                Recalculate();
            }

           
        }
    }
}