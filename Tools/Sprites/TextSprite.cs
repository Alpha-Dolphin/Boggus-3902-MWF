/*
 *Implements ISprite for text
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Tools.Interfaces;

public class TextSprite : ISprite
{
    private SpriteFont font;
    private string text;
    private Vector2 position;
    private Color color = Color.White;

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, position, color);
    }

    public void SetFont(SpriteFont spriteFont)
    {
        font = spriteFont;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public void SetText(string text)
    {
        this.text = text;
    }
    public void SetPosition(int x, int y)
    {
        position = new Vector2(x, y);
    }

    public void Update(int x, int y)
    {
        throw new System.NotImplementedException();
    }

    public bool Finished()
    {
        throw new System.NotImplementedException();
    }
}