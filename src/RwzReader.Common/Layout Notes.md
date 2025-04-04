# RWZ File Layout

- `x002c` = # of entries in file
- `header` = 31 bytes header starts and ends with same 3-byte sequence, different per file
- `RuleElement` `x0020` after end of first rule name
- `x0014` bytes after name, is size of data record
- `x0106` after data size bytes, email from address starts (116 when first rule),
- `x00a6` when exchange address book entry,
- `x00f6` when pst address book
- `x0037` after data size bytes, word match starts (47 when first rule)
  - If exchange data store, data contains `EMSMDB.DLL`, if PST, data contains `mspst.dll`

- `FILEHEADER` (bytes `00`-`2D`)
  - `2C`-`2D` - Number of Rule Entries in file

- `RULEITEM` (size varies)
  - `00`-`04` - Header
  - `05`-`06` - Length of name (`NAMELEN`)
  - `07`-`07+NAMELEN` - Name text Unicode
  - `+14` bytes padding
  - `+2` length of data block
