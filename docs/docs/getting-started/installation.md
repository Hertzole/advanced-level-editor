---
sidebar_position: 1
---

# Installation

Currently, only the development package is available. It's updated with each commit to the master branch.   

1. Add the OpenUPM registry.  
   Click in the menu bar Edit → Project Settings... → Package Manager  
   Add a new scoped registry with the following parameters:  
   Name: `OpenUPM`  
   URL: `https://package.openupm.com`  
   Scopes:  
   - `com.openupm`  
   - `com.neuecc.messagepack`

![Package Manager settings](/img/getting-started/packages.png)

2. Open the package manager and click 'Add from Git url' in the top right corner.
3. Paste in `https://github.com/Hertzole/advanced-level-editor.git#dev-package` and click enter.

![Package Manager Add](/img/getting-started/package-manager.png)

4. Wait for the installation to complete.

The package should now be installed! Check out the [Quick Start](/docs/getting-started/quick-start) to get up and
running with ALE.