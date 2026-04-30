# Runtime OBJ Importer (URP)

Wavefront `.obj` + `.mtl` importer that runs at runtime **and** in the Editor. Materials are created against the **Universal Render Pipeline / Lit** shader, so it slots straight into a URP project.

This is a fork of [Dummiesman's Runtime OBJ Importer](https://assetstore.unity.com/packages/tools/modeling/runtime-obj-importer-49547), repackaged as a Unity Package Manager (UPM) package and updated for Unity 6.x / URP.

## Requirements

- Unity **2022.3 LTS** or newer (verified against Unity 6.3 + URP).
- The **Universal RP** package installed and a URP asset assigned in *Project Settings → Graphics*.

## Installation

### Option 1 — Install via Git URL

In Unity, open **Window → Package Manager**, click the **+** button → **Install package from git URL...**, and paste:

```
https://github.com/EDivePlus/unity-runtime-obj-importer.git
```

### Option 2 — Add to `manifest.json`

In `Packages/manifest.json` add:

```json
{
  "dependencies": {
    "com.ediveplus.objimporter": "https://github.com/EDivePlus/unity-runtime-obj-importer.git"
  }
}
```

### Option 3 — Local install

Clone the repo and use **Package Manager → + → Install package from disk...**, selecting this repo's `package.json`.

## Player builds

The importer creates materials with `Shader.Find("Universal Render Pipeline/Lit")` at runtime. For a Player build to find that shader you must add it to **Always Included Shaders**:

1. Open *Project Settings → Graphics*.
2. Under **Always Included Shaders**, add an entry and pick `Universal Render Pipeline/Lit`.

The first build after this change can take a while as Unity compiles every shader variant.

## Usage

```csharp
using Dummiesman;

// From a file path (also loads any MTL referenced by the OBJ).
var go = new OBJLoader().Load("C:/models/teapot.obj");

// From a stream (no materials — supplies a default white material).
using (var stream = File.OpenRead("C:/models/teapot.obj"))
    go = new OBJLoader().Load(stream);

// OBJ + MTL streams.
using (var objStream = File.OpenRead("teapot.obj"))
using (var mtlStream = File.OpenRead("teapot.mtl"))
    go = new OBJLoader().Load(objStream, mtlStream);
```

In the Editor you also get a **GameObject → Import From OBJ** menu item.

## Samples

Two example scripts are shipped under `Samples~/RuntimeImport/`. Import them via the Package Manager UI (select the package → **Samples → Import**):

- `ObjFromFile` — UI for loading an `.obj` from a path on disk.
- `ObjFromStream` — downloads an `.obj` over the web (`UnityWebRequest`) and parses it from memory.

## Features

- Material file (MTL) loading with diffuse/bump/specular/emission maps.
- Runtime texture loader supporting **BMP, TGA, JPG, PNG, DDS, CRN**.
- Decent import speed (~750k triangles in ~10s).
- Loads triangles, quads, and ngons.
- Works in Editor and at runtime.
- Stream-based loading with overridable texture-load callback.

## License

MIT — see `LICENSE.md`. All credit to the original author, Dummiesman.
