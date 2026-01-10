Apollo SDE(tm) 
Version 6.1.0.8
Oct. 6th, 2003

(c) 1999-2003 Vista Software. All rights reserved.
www.vistasoftware.com
----------------------------------------------------------------

The Apollo SDE, also known as the Apollo API, is a high-performance 
xBase database runtime engine that is used by Apollo data engines to 
support CA-Clipper, FoxPro and our own HiPer-SIx data files. 

The SDE is designed to work with Apollo engines. Developers may call 
the Apollo SDE functions directly using the API include files found in
C:\Apollo\SDE60\Include. The SDE include files have support for 
VB, VC++, PowerBasic and Delphi.

	A) Installation and Deployment
	B) Latest 6.1 Files
	C) DLL Search Order
	D) Collation (data sorting rules)
	E) Include Files
	F) New/Changes in 6.0
	G) New/Changes in 6.1
-------------------------------------------------------
A) Installation and Deployment

To deploy an SDE-based application, you must copy the following
files to your destination computer:

	C:\Apollo\SDE60\SDE*.DLL
	to
	C:\WinNT\System32
	-or-
	C:\Windows\System

----------------------------------------------------------------
B) Latest 6.1 Files

Documentation and additional help files can be found on-line at:
www.vistasoftware.com. The SDE file set consist of the following files:

   SDE61.DLL
   SDECDX61.DLL
   SDENSX61.DLL
   SDENTX61.DLL
   APOLLOCRYPT.DLL	(Optional for Client/Server encryption)

In order to avoid conflicts with previous versions of the SDE , this 
new SDE 6.0 release is now distributed as *61.DLL file set.

----------------------------------------------------------------
C) DLL Search Order

The following outlines the order which your applications finds and uses
the SDE DLLs located on your computer:

1. SDE*.DLL files located in the same directory as the EXE. 

2. c:\WinNT\System32 	(NT/Win2000) or
   c:\Windows\System 	(Win98/95)

----------------------------------------------------------------
D) Collation (data sorting rules)

A new collation sample is included that shows how the SDE sorts data
under the various environments (Windows, DOS OEM, locales).  

   C:\Apollo\SDE61\Collation\CollationSample.exe

The SDE 6.1 supports user-defined sorting rules. See the various 
Apollo help files for more details.

See: www.vistasoftware.com/downloads.asp 

----------------------------------------------------------------
E) Include Files

The SDE now includes the API declarations for the SDE DLLs in the following
directory:
	C:\Apollo\SDE60\Include

ADBX61.bas	// Apollo X Interface (ADBX60.DLL) for VB

FTS32.bas	// Fast Text Search for VB
FTS32.H		// Fast Text Search for C
FTS32.lib	// Fast Text Search for C
FTS32.pas	// Fast Text Search for Delphi
FTS32.pb	// Fast Text Search for PowerBasic

SDE61.bas	// Apollo API (SDE) for VB
SDE61.h		// Apollo API (SDE) for C	
SDE61.lib	// Apollo API (SDE) for C
SDE61.pas	// Apollo API (SDE) for Delphi
SDE61.pb	// Apollo API (SDE) for PowerBasic

----------------------------------------------------------------
F) New/Changes in 6.0

FIXES
---------------------------------------

-  It is highly recommended that indexes be rebuilt using this new 6.0 DLL set.
   A very old bug in the indexing engine was found in fixed in this release.
-  Early Clipper file combination of DBF/DBT/NSX now supported: RDD type 4
      	1 = CDX, 2=NTX, 3=NSX, 4=NSX_DBT 
-  Pack operations added garbage data into R_MEMO fields if table was encrypted, 
   under Win9x. This bug was not present on Win2K. FIXED
-  In some cases, incorrect appending or coping of R_BITMAP memo fields from 
   another table occurred. FIXED
-  An overall performance slow down was experienced when SetScope and 
   SET DELETED = ON were used. This was tracked down to a data dependent 
   issue. FIXED 
-  FOR clause specified in an index tag sometimes caused other tags to not 
   be built, and in some cases caused an AV. Fixed.
-  A FOR clause in an index sometimes causes FoxPro to not find records. Fixed.
-  Some seek operations would fail using International characters. Fixed.
-  Index tags that contained an expression based on a field that contained
   international characters caused an AV when accessing the CDX. Fixed.
-  Extremely slow appending records using NSX indexes. Fixed.
-  Long standing issue related with CDX and NSX index tree depth. FIXED
   This bug triggered an AV after some arbitrary index data limit was exceed.
- When calling sx_SetDeleted(..) while a Table is open, the Timestamp of
   the Table change to current date during sx_Close, even if the table was not
   altered. FIXED
-  Usage of operators AND, OR and NOT raised incorrect results for Query. FIXED.
   Caused indirectly by LIKE operator implementation in previous build.
- Fixed improper treatment for Hong-Kong regional settings- sx_SetScope now 
  truncates string values containing double quotes
- Fixed incorrect treatment of soft-carriage and escape in FPT memo fields
- Fixed incorrect automatic unlock in sx_Commit before file buffers were flushed 
    and user's sx_Unlock was applied
- AV, if sx_SetCollationRule(3,...) issued under VB. FIXED
- Incorrect export for sx_SetUserDelimiter in SDE50.DLL caused AV
    in VCL 5.2 RC5. FIXED
- Zeroes in date cluster in the DBF header immediately after new table
    was created. FIXED
- Incorrect Seek for Duden ordered sets. FIXED
- Indexing on 'C' fields containing binary data and sx_SeekBin. FIXED
- Clipper NTX indexes were being opened twice with the short name and
  full path name in the same workarea. FIXED
- sx_AppendFrom and simultaneous sx_SetGaugeHook fails for appending from DBF. FIXED
- sx_GetSystemLocale causes AV under VB. FIXED
- Temporary index was created incorrectly for READONLY mode. FIXED

NEW
---------------------------------------
-  Support for new operators '=>' and '=<' in the FOR clause of Queries, has been 
   added for backwards compatibility with FoxPro 
-  New file: APOLLOCRYPT.DLL required for encrypting/decrypting data when
   communicating with the Apollo Server
- Added new xBase operator 'LIKE'.  Respects standard SQL LIKE operator, 
   except standard specified 'escape' symbol.
-  Added support to set constant 2005/SDE_SP_BDESPECIFIC using sx_SysProp
   which toggles LIKE behavior to be compatible with either BDE or Oracle.
   BDE behavior is the default.
- Added ability to set User delimiter symbol for sx_AppendFrom and sx_CopyFileText 
   calls with new sx_SetUserDelimiter method;
- Added automatic merging of lines for single memo field in FTP

Parameters:
sx_SetUserDelimiter( Symbol, Trim, Memo) -> Returns previously set delimiting character
 Symbol: byte - the user's symbol for delimitation of fields in ASCII file 
Trim: 4-byte boolean - if set into non-zero, the trim operation is made for 'C' fields
Memo: 4-byte boolean - if set into non-zero, the memo fields are marked (but with zero context)

Return value:
Returns (byte) - previous user's delimiting char

The respective updates products:

VCL component (v. 5.2) -

- Following lines have been added to ApoDSet.Pas at line 167:

   USER_DELIM   = 25;    {M.O. 06-01-01, added}

   // Collation rules    {M.O. 06-01-01, added}
   ALPHABET  = 0;
   SPELLING  = 1;
   EXPANDING = 2;
   MACHINE   = 3;

- By default, the year byte in the DBF header is set as: [CurrentYear-1900]
  but according to DBase III+ rules, it should be: [Current Year / 100]
  It is now possible to set DBase III+ rules with:
	sx_SysProp(2006, Pointer(0) )  // off (default) 
 	sx_SysProp(2006, Pointer(1) )  // on (uses: Current Year / 1900)

- Added expanded, native boolean logic to sx_Query.
   Now supports (case insensitive): .T., True, .F., and False.
- Includes new ADBX60.BAS interface file for new ADBX engine. ADBX is a high-level
   API which allows Apollo engines to work in Local mode or Client/Server using
   the same set of code. When in local mode, API calls are directed to the SDE. 
   When in client/server mode calls are sent to the Apollo Server. SQL calls are
   managed the same way - local SQL gets directed to the local ApolloSQL.DLL 
   and client/server SQL calls are sent the Apollo Server for processing.
- Updated include files (C:\Apollo\SDE60\Include)
- New SDE collation functions:
 	sx_AddDudenCollation	// adds Duden collation support
  	sx_AddEtecCollation	// adds ETEC collation support
  	sx_GetSystemCharOrder	// get system character order
  	sx_GetSystemLocale	// get system locale
  	sx_SetMachineCollation	// sets machine collation
  	sx_SetSystemCollation	// sets windows system collation
- New fast algorithm for Duden sorting
- Enhanced seek for keys with additional sorting by groups (ETEC collation)   

- New important function sx_CommitLevel( nCommitLevel). 
  Regulates how sx_Commit saves data by giving full control over the 
  SDE and Windows OS buffering and implicit lock sub-system.
	Levels: 0, 1, 2
  CommitLevel Rules:
	1. Cannot change CommitLevel after sx_Use has already been 
	    called for a table.
	2. Cannot change CommitLevel for new workarea if the same 
	    DBF has already been opened in another workarea. There is one 
	    buffer per table and it is re-used for each instance that the DBF is openend.
	3. CommitLevel is Global and it is assigned to each new workarea during
	    opening/creation.
- New sx_UseEx and sx_CreateNewEx functions allow you to set the 
  CommitLevel for individual tables. These functions accept CommitLevel 
  as an additional 'mode' parameter, if it needs to use a level other than 
  the Global setting. Due to that, we resored back to:
  sx_CommitLevel(nCommitLevel) [only one parameter ]
- New function sx_IsNull. Operates similar to sx_Empty, except it optimizes
numeric and logical fields calculations for better performance.

1. New properties SDE_SP_SETAUTOPAD [2007] and SDE_SP_GETAUTOPAD [2008] allowing to set/reset auto pad routine during index creation for character key, if final key length variables
2. New information function sx_GetCommitLevel.

OBSOLETE
--------------------------------------------
- Flag SDE_SP_PUTOBUFFER no longer used
- Flag SDE_SP_SETOBUFFER no longer used

- SDE 6.0.0.5 has been compiled with MVS 6.0 Service Pack 4

----------------------------------------------------------------
G) New/Changes in 6.0.0.11

---------------------------------------
CHANGES
---------------------------------------
6.0.0.6	1/25/2002
- Internationalization for resource strings (error messages and FilterDialog text). 
   Support of resource library SDERC60.DLL
------------------
6.0.0.7	02/19/2002
- Optimized bitmap was limited in size to grow more than 1024 bits. 
  Caused AV during append operations after optimized query was issued. FIXED
- Table instance opened in ReadOnly mode before same table instance in 
  ReadWrite mode did lead to incorrect tables handling. FIXED
- Added support of sx_SetErrorFunc for VB
- Increased size limit for memo files from 2GB to 4GB
- Enhanced low file operation error messages
------------------
6.0.0.7 02/19/2002
- Optimized bitmap cannot be larger than 1024 bits. It causes AV during append 
  operations if optimized query is issued. FIXED
- If table instance is opened in ReadOnly mode before another instance opens it in
  ReadWrite mode, it leads to incorrect handling for both tables. FIXED
------------------
6.0.0.8	02/20/2002
- '@' symbol placed at first position in memo caused the loss of memo 
   field information. FIXED
- sx_Reindex and sx_Pack now return success/failure (true/false) execution status. NEW

------------------
6.0.0.9 02/28/2002
- 'F' field type is hidden with 'N' type causing compatibility problems. FIXED
------------------
6.0.0.10 03/04/2002
- Bloat in DBT memo. FIXED
------------------
6.0.0.11 03/12/2002
- Not all records were being appended from text files using sx_AppendFrom. FIXED
------------------
6.0.0.12 06/04/2002
- Non filtered record gets stuck in NTX index with FOR expression, when record 
  is updated and later goes out of index. FIXED
- Special release for restricting collation with binary (machine collation) only
------------------
6.0.0.13 07/05/2002
- Indexing on memo fields with Hi-Per and Fox drivers
- New additional set of xBase functions.
  
------------------
6.0.0.14 07/10/2002
- Incorrect AppendFrom from comma delimited text file, when quoted comma is 
  placed on first position of character field. FIXED
- Incorrect AppendFrom from comma delimited text file, when quoted string 
  is separated by spaces from comma delimiter. FIXED
- Filtered record are not inserted into NTX index with FOR expression when 
   table is updated. FIXED (final fix for respective issue in SDE 6.0.0.12)
- Support for Hi-Per local indexes. (NSX extension marks index as local for SDE. 
  It allows FLock to be excluded when DBF is indexed.) NEW
- XML record formatting from current record context: sx_GetXML. NEW

------------------
6.1.0.0 10/01/2002
- new 6.1 SDE engine. DLL files names remain the same.
- Updates were not saved for text memos in Hi-Per and Fox drivers if there are 
  no open indexes. FIXED
- New functions: 
	sx_PutDateString
	sx_PutDouble
	sx_PutInteger
	sx_PutLogical
	sx_PutLong
	sx_PutString
	sx_PutMemo

- First time update never occurs with sx_Replace in mutliuser mode for Fox and Hi-Per, 
  if structural index is opened and order set to 0. FIXED
- new SDE61\XML sample project

------------------
6.1.0.1 11/20/2002

- Incorrect sx_QueryRecCount result for long query filter expression and 
  sx_SetDetleted set to false. FIXED
- If several memos are present in a memo file, memo context may not be encrypted 
  for all fields. FIXED

------------------
6.1.0.3 12/11/2002

- AppendFrom and encryption support for VFP tables with memos. NEW

------------------
6.1.0.4 1/8/2003

- Renamed all SDE files from 60 to 61 (e.g. SDE61.DLL)

------------------
6.1.0.5 1/31/2003

- New INT and FLOAT xBase functions to convert Date type value to Delphi compatible 
  integer number of days that have passed since 12/30/1899

------------------
6.1.0.6 2/6/2003

- New sx_TagCount and sx_TagInfo SDE functions that return the # of tags in a 
  compound index file (e.g. CDX, NSX) and returns the individual tag information.
  (see: TTagStructure, TApolloTable.TagCount and TApolloTable.TagInfo in apodset.pas)

------------------
6.1.0.7 3/1/2003

- Unexpected results for several RYOFilter handlers. FIXED

------------------
6.1.0.10 3/19/2003

- AV for queries with INT and TRUNC xbase functions operating on date types. FIXED

------------------
6.1.0.11 3/21/2003

- Encryption was not applied to tables with multiple memo fields, after the
  first memo field in the Hi-Per SIx driver. FIXED

------------------
6.1.0.12 3/24/2003

- Blank dates are now distinguished from from zero dates.

------------------
6.1.0.13 3/31/2003

- AV for certain combination of SetScope and SetOrder in multi-user mode 
  in Clipper driver. FIXED

------------------
6.1.0.14 3/24/2003

- 'Waiting for lock' message is reported for ERRORLEVEL_STANDARD only.
- Number of file handles (i.e. workareas) have be reset to original values.
- Fixed support for Thai locale
------------------
6.1.0.15 7/23/2003

- Fixed freezing when loading two-byte regional settings (including Thai)
------------------
6.1.0.16 8/4/2003

- Fixed support for Turkish locale

------------------
6.1.0.17 10/6/2003

- Filter such as: "DateField > Ctod('01/01/2003')" returned records with blank dates. FIXED
========================================================================
<eof>
