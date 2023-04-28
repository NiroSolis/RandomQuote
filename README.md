# RandomQuote for Windows Sign In
## What this does
This program will add a random quote to the Windows registry to be displayed before a user signs in.  The registry key is used by Local Group 
Policy, so if you are using that for any other purpose, then DO NOT use this program, since it will overwrite any message set there.  Also note that it must be run as Admin.

If you have reservations about messing with the Windows registry, be aware that this does modify two values under a single key:
<pre><code>KEY: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System
VALUE: legalnoticecaption (used for author)
VALUE: legalnoticetext (used for quote)</code></pre>

This program requires .Net and was tested on Windows 10 and 11.

## How to use
First, create a `quotes.txt` file and place it in the same directory as the executable.  The `quotes.txt` file should be formatted as below:

<pre><code># This is a comment
Author|Quote by that author
Author|Another quote</code></pre>

That's it.  The `#` at the beginning of the line means it is a comment and will be ignored.  Each line should contain the author's name, a pipe character `|`, and then the quote.  Blank lines will also be ignored.

Currently, if there is a problem with the quote (for example, the pipe character is missing), the program will exit quietly with no error given.  Future updates will add messaging, retry attempts and logging.

## Use case
Personally, I created a shutdown script in Windows using the Group Policy Editor that runs this program everytime I shutdown or restart.  You can run it manually of course at any time.  Keep in mind that this quote will only be seen when logging in to a new session in Windows.  It does not appear when resuming from a locked session.

Here's a tip.  If you create a shortcut to this program, you can then go into the shortcut's properties, click advanced, and then enable "Run as administrator" to automatically make it run as Admin.
