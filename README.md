# README #

A Proof-of-concept for the Morse code project that I am envisioning. I wrote this using VS Code and the dotnet core cli.

### How do I get set up? ###

If you install the dotnet core cli (link below) you can use the command "dotnet run" in the MCDoodle.API directory and see the output in the console.

If you want to translate your own custom input I'm just storing it in a txt file in the MCDoodleData directory and reading it. Feel free to play around with the values. My coding game isn't strong yet so bear with me :)

Download dotnet core cli: https://www.microsoft.com/net/learn/get-started/macos

A good introduction to the cli (I mostly use it for adding projects and references to the solution file, so you can probably contribute just fine without using it:
https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x

### Contribution guidelines ###

You don't have to contribute or anything since this isn't the language we'll ultimately go with, but at the same time don't let me tell you how to live your life.

### Anticipated Steps ###
// Step 1: Write a method that will convert English input into Morse dot notation. (done)
// Step 2: Write a method that will convert Morse dot notation into English. (optional)
// Step 3: Write a method that will take dot notation and output it with audio. (raspberry pi)
// Step 4: Write a method that will take dot notation and output it with visuals (light, etc). (raspberry pi)
// Step 5: Write a method that will allow custom input and save it in some format. (can be with a touch screen or an actual morse key, or even the space bar... idc)
// Step 6: Write a method that will take the custom input (in whatever format) and play it with audio/visual. <-- this way we could record a message and just email it to somebody where they can read/listen to it whenever