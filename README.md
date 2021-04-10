Guest Password Manager
======================

Allows authorised users to reset passwords for guest user accounts in Active Directory and export the temporary password.

This application is to be used by sufficiently privileged end users to set the password. Password rotation at the end of
the day is performed by other software.

This requires the machine on which it is running to be a member of an Active Directory domain.


## Licence

This software is made available under an Apache-style licence. See `LICENSE`.

## Dependencies and Packages

### MlkPwgen

This software uses MlkPwgen, copyright (c) 2017 Michael Kropat.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

### Apache log4Net

Available under the Apache License, Version 2.0. [http://logging.apache.org/log4net/license.html](http://logging.apache.org/log4net/license.html)

### Active Directory Object Picker Control

Code in `ADPicker.cs` originally [written by Marc Merritt](https://www.codeproject.com/Articles/6848/Active-Directory-object-picker-control).

Available under the [Code Project Open License (CPOL) 1.02](https://www.codeproject.com/info/cpol10.aspx)

### Icon

The icon is derived from [Open Iconic](https://useiconic.com/open/), released under [MIT License](https://github.com/iconic/open-iconic/blob/master/ICON-LICENSE)
