Read the following before using the files within this archive.  

This archive contains source files that belong to the "Creating a preloader" article posted on the Adobe Developer Connection: 
http://www.adobe.com/devnet/actionscript/articles/lightweight_as3.html

These files demonstrate building a simple, multipurpose preloader that both designers and developers can leverage. 

Unpack the archive wherever you choose. The files should remain relative to one another, as follows:

	{Unpack Dir}/dev/
	   _classes/
	   loadedContent.fla
	   sampleLoader.fla
	{Unpack Dir}/_deploy/
	   content.xml
	   loadedContent.swf
	   loader.swf

dev/ is the directory where all development is done. 
dev/_classes/ contains all of the ActionScript used in the FLAs.
sampleLoader.fla exports to {Unpack Dir}/_deploy/loader.swf. This contains the preloader artwork.
loadedContent.fla exports to {Unpack Dir}/_deploy/loadedContent.swf. This contains a SWF that will be loaded into loader.swf