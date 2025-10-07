## Dummiesman's OBJ Importer - Fork

### Adapted to work with *Universal Render Pipeline/Lit shader*.

Works during runtime, and in editor! A couple of code samples are provided in the Samples folder.

---

## Runtime Import Note

You must go to the "Graphics" tab in your project, and add "Universal Render Pipeline/Lit" to the always included shaders. This will make your next build take a while.

---

## Features

- Material file loading
- Runtime texture library supporting BMP, TGA, JPG, PNG, DDS, and CRN textures.
- Decent import speed (~750k triangles in about 10 seconds)
- Support for loading obj and mtl from stream, as well as overridable callback for texture loads
- Works in editor, and during runtime
- Loads triangles, quads, and ngons

---

## Original Work
[Runtime OBJ Importer Unity Plugin](https://assetstore.unity.com/packages/tools/modeling/runtime-obj-importer-49547) by Dummiesman. <br>
All credit goes to the original author, Dummiesman. This fork is provided as-is, under the same license as the original package