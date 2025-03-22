# Ghost Recon Future Soldier Backend

Quazal Rendez-Vous (RDV) emulator for Ghost Recon: Future Soldier.

## Disclaimers
This project **does not** intend to emulate or bypass Ubisoft Connect services - in order to run the game you need a regular activation key acquired from Ubisoft and linked to your Ubi account.

## Config

Unlike GRO, the game doesn't use Yeti.ini file. The configuration is likely acquired from remote services.

## Projects
- DareDebuggerWV : tool to interface the daredebug port of the game
- DTBReaderWV : converts .dtb files to .csv
- GROBackendWV : experimental backend for GRO
- GRODedicatedServerWV : experimental DS for GRO
- GROExplorerWV : tool to browse the yeti.big file for game content
- GROMemoryToolWV : tool to browse various stuctures like lists and trees in memory
- NamespaceParserWV : Extracts custom RTTI information found in different exe and dll

## Credits

- [Warranty Voider](https://github.com/zeroKilo) - the main author of [GRO codebase](https://github.com/zeroKilo/GROBackendWV)
- [Kinnay](https://github.com/kinnay) - extensively documented research on Quazal protocols ([wiki](https://github.com/kinnay/NintendoClients/wiki/))
