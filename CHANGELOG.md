# Changelog

All notable changes to this package are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-04-30

### Added
- Repackaged as a Unity Package Manager (UPM) package with `Runtime/` and `Samples~/` layout.
- `Dummiesman.OBJImporter` assembly definition.
- `Dummiesman.OBJImporter.Samples` assembly definition for the runtime samples.
- Verified against Unity 6.3 with the Universal Render Pipeline.

### Changed
- `OBJLoaderHelper.EnableMaterialTransparency` now configures URP Lit transparency
  (`_Surface`, `_Blend`, `_SURFACE_TYPE_TRANSPARENT`, `RenderQueue.Transparent`)
  instead of the legacy Standard-shader path (`_Mode`, `_ALPHABLEND_ON`).
- `MTLLoader` now triggers transparent mode for `RGBA32` / `BGRA32` textures
  (previously only `DXT5` / `ARGB32`), which fixes PNG textures with alpha.
- `MTLLoader` is now in the `Dummiesman` namespace (was global).
- Sample `ObjFromStream` rewritten to use `UnityWebRequest` instead of the
  obsolete/removed `WWW` class.
