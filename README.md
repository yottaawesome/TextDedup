# TextDedup
A small console app that deduplicates a text file's contents.

## What's the motivation?
Ever been annoyed with bumping into Windows' PATH environment level limit, then looking at the variable and being extra annoyed at the duplicate entries? 

I have. Many times. 

TextDedup was designed to assist with quickly deduplicating a body of text in a text file. This way, I just need to copy the PATH environment variable into a text file, run the utility, and a deduplicated text file is outputted. I can then choose to split the contents into multiple system variables to fit all the content.

Obviously, a complete utility would update the PATH automatically (this involves updating the registry), but this was intended as a quick scratch of an annoying itch, and deduplicating file text might be useful beyond just the use case I've presented. A more complete utility will follow at a later date.

## Publishing
From a command prompt, `cd` into `src` and run the following: `dotnet publish -c Release -r win10-x64`.

## Switches
Invoke from the command prompt.

* `/src:` 
    * _Required._ 
    * The file that contains the data to be deduplicated.
* `/dst:`
    * _Optional; defaults to_ _**\<filename\> [deduped].\<extension\>**._ 
	* The destination file to receive the deduplicated text.
* `/del:`
    * _Optional; defaults to ';'._ 
	* The file that contains the data to be deduplicated.
    

_Example:_ `tddp /src:test.txt /dst:deduped-test.txt /del:||` 

## Stuff left to be done?
More unit tests. More testing in general. Also, a C++ version, because the C# .NET core version is a 60+MB monstrosity. IsN't .NeT tEh AwSuUmz?