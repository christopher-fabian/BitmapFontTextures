# BitmapFontTextures

A .NET Tool and Library for converting .ttf to .png for Bitmap Font Textures in MonoGame (3.8.4+).  

# Benefits

- Create textures of pixel fonts
- (Optional) The texture only contain the characters used
- No additional classes, no overhead at runtime - just ContentManager.Load<SpriteFont>()

# How to Use

1.  Clone this repository.

2.  Build BitmapFontTextures and BitmapFontTextures.Content.

3.  Click "Choose Text Files" and choose whatever files you are using to store your text or "Export Default (32 .. 126) for fast creation.

![image](https://github.com/user-attachments/assets/879f3a4f-a033-497e-9f9c-8cfc76c34cb4)

4.  Click Export.  It will ask you where to save the output bitmap... BUT it is also saving a .txt file of the same name that lists all the unique characters in your game's text.  You need to keep this text file around (add to perforce, etc.) so that the content importer/processor can match up the glyphs to the characters.

5.  Go ahead and edit the texture, just don’t move any of the glyphs out of order.  Chances are some characters still rendered wonkily, but now you can fix them in photoshop.

6.  Open up the MonoGame Pipeline Tool and your content.mgcb file.  Select the root node, and at the bottom, add a reference to the BitmapFontTextures.Content.dll you built earlier.

![image](https://github.com/user-attachments/assets/3343def9-7c7f-4872-b3e8-5c7a440e1b62)

7.  Now Add the bitmap you just made to the project.

![image](https://github.com/user-attachments/assets/cc698bda-1768-4d3d-af8b-a26b74d9a809)

8.  Under Importer, choose "Bitmap Font Texture - Importer", and under Processor choose "Bitmap Font Texture - Processor".  Set the 'FirstCharacter' field to 0; it remains since we subclassed the default Font Importer, but the default value of 'space' gets serialized to an empty string, which causes MGCB to believe it "NeedsRebuild", unless you change it.

9.  Build your content and you should be done with this part.

10.  To use the font in game, it works exactly like any other sprite font; use ContentManager.Load<SpriteFont>(fontName) and it should work as usual.


# Credits
The idea and base sources were taken from Thomas Happ (The Creator of Axiom Verge)

See https://www.axiomverge.com/blog/localized-font-textures-in-monogame
