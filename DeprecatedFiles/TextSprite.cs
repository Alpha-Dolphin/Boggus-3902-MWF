/*
 *Implements ISprite for text
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextSprite : ISprite
{
    private SpriteFont font;
    private string text;
    private Vector2 position;

    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, position, Color.Black);
    }

    public void initialize()
    {
        throw new System.NotImplementedException();
    }

    public void update()
    {
        throw new System.NotImplementedException();
    }

    public void setFont(SpriteFont spriteFont)
    {
        font = spriteFont;
    }

    public void setText(string text)
    {
        this.text = text;
    }
    public void setPosition(int x, int y)
    {
        position = new Vector2(x, y);
    }
}