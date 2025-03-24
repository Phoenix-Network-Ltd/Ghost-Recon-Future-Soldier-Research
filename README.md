# Ghost Recon Future Soldier Backend

Quazal Rendez-Vous (RDV) emulator for Ghost Recon: Future Soldier.

## Disclaimers
This project **does not** intend to emulate or bypass Ubisoft Connect services - in order to run the game you need a regular activation key acquired from Ubisoft and linked to your Ubi account.

This is non-for-profit emulation software meant for game preservation purposes, **not for commercial use**.

## Config

Unlike GRO, the game doesn't use `Yeti.ini` file. The configuration is likely acquired from remote services.

To redirect game traffic to your local server add the below [`hosts`](https://en.wikipedia.org/wiki/Hosts_(file)) file entry:
```
127.0.0.1 onlineconfigservice.ubi.com
```

You can run the server directly with `runme.bat` startup script or through Visual Studio's debugger.

## Projects
- `DareDebuggerWV` - tool to interface the daredebug port of the game
- `DTBReaderWV` - converts .dtb files to .csv
- `GRFSBackend` - experimental Rendez-Vous backend for GRFS
- `NamespaceParserWV` - extracts Quazal's DDL type information found in game binaries (EXE/DLL)
- `QuazalSharkWV` - custom packet log analyzer
- `QuazalWV` - implementation of Quazal's protocol stack

## Credits

- [Warranty Voider](https://github.com/zeroKilo) - the main author of [GRO codebase](https://github.com/zeroKilo/GROBackendWV)
- [Kinnay](https://github.com/kinnay) - extensively documented research on Quazal protocols ([wiki](https://github.com/kinnay/NintendoClients/wiki/))
